using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Models;
using WorkflowEngine.Services;

namespace WorkflowEngine.Controllers
{
    /// <summary>
    /// API controller for managing workflow instances (runtime operations).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowInstancesController : ControllerBase
    {
        private readonly WorkflowRepository _repository;

        /// <summary>
        /// Constructor with dependency injection of the repository.
        /// </summary>
        public WorkflowInstancesController(WorkflowRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Starts a new workflow instance for a given workflow definition.
        /// </summary>
        /// <param name="workflowDefinitionId">The workflow definition ID.</param>
        /// <returns>The created workflow instance or an error.</returns>
        [HttpPost("/api/workflows/{workflowDefinitionId}/instances")]
        public IActionResult StartWorkflowInstance(string workflowDefinitionId)
        {
            var definition = _repository.GetWorkflowDefinition(workflowDefinitionId);
            if (definition == null)
                return NotFound($"Workflow definition '{workflowDefinitionId}' not found.");

            var initialState = definition.States.FirstOrDefault(s => s.IsInitial);
            if (initialState == null)
                return BadRequest("Workflow definition does not have an initial state.");

            var instance = new WorkflowInstance
            {
                Id = Guid.NewGuid().ToString(),
                WorkflowDefinitionId = workflowDefinitionId,
                CurrentStateId = initialState.Id,
                History = new List<ActionHistory>()
            };
            _repository.AddWorkflowInstance(instance);
            return CreatedAtAction(nameof(GetWorkflowInstance), new { id = instance.Id }, instance);
        }

        /// <summary>
        /// Executes an action on a workflow instance, moving it to the target state if valid.
        /// </summary>
        /// <param name="id">The workflow instance ID.</param>
        /// <param name="request">The action execution request (actionId).</param>
        /// <returns>The updated workflow instance or an error.</returns>
        [HttpPost("{id}/actions")]
        public IActionResult ExecuteAction(string id, [FromBody] ExecuteActionRequest request)
        {
            var instance = _repository.GetWorkflowInstance(id);
            if (instance == null)
                return NotFound($"Workflow instance '{id}' not found.");

            var definition = _repository.GetWorkflowDefinition(instance.WorkflowDefinitionId);
            if (definition == null)
                return NotFound($"Workflow definition '{instance.WorkflowDefinitionId}' not found.");

            var currentState = definition.States.FirstOrDefault(s => s.Id == instance.CurrentStateId);
            if (currentState == null)
                return BadRequest("Current state not found in workflow definition.");

            if (currentState.IsFinal)
                return BadRequest("Cannot execute actions on a final state.");

            var action = definition.Actions.FirstOrDefault(a => a.Id == request.ActionId);
            if (action == null)
                return BadRequest($"Action '{request.ActionId}' not found in workflow definition.");

            if (!action.Enabled)
                return BadRequest($"Action '{action.Name}' is not enabled.");

            if (!action.FromStates.Contains(currentState.Id))
                return BadRequest($"Action '{action.Name}' cannot be executed from the current state '{currentState.Name}'.");

            var targetState = definition.States.FirstOrDefault(s => s.Id == action.ToState);
            if (targetState == null)
                return BadRequest($"Target state '{action.ToState}' not found in workflow definition.");

            // Update instance state and history
            instance.CurrentStateId = targetState.Id;
            instance.History.Add(new ActionHistory
            {
                ActionId = action.Id,
                Timestamp = DateTime.UtcNow
            });
            _repository.UpdateWorkflowInstance(instance);
            return Ok(instance);
        }

        /// <summary>
        /// Retrieves the current state and history of a workflow instance.
        /// </summary>
        /// <param name="id">The workflow instance ID.</param>
        /// <returns>The workflow instance or NotFound.</returns>
        [HttpGet("{id}")]
        public IActionResult GetWorkflowInstance(string id)
        {
            var instance = _repository.GetWorkflowInstance(id);
            if (instance == null)
                return NotFound();
            return Ok(instance);
        }

        /// <summary>
        /// Request model for executing an action on a workflow instance.
        /// </summary>
        public class ExecuteActionRequest
        {
            /// <summary>
            /// The ID of the action to execute.
            /// </summary>
            public string ActionId { get; set; }
        }
    }
} 