using Microsoft.AspNetCore.Mvc;
using WorkflowEngine.Models;
using WorkflowEngine.Services;

namespace WorkflowEngine.Controllers
{
    /// <summary>
    /// API controller for managing workflow definitions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowDefinitionsController : ControllerBase
    {
        private readonly WorkflowRepository _repository;

        /// <summary>
        /// Constructor with dependency injection of the repository.
        /// </summary>
        public WorkflowDefinitionsController(WorkflowRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Creates a new workflow definition.
        /// </summary>
        /// <param name="definition">The workflow definition to create.</param>
        /// <returns>The created workflow definition or a validation error.</returns>
        [HttpPost]
        public IActionResult CreateWorkflowDefinition([FromBody] WorkflowDefinition definition)
        {
            // Basic validation: must have exactly one initial state
            if (definition.States == null || definition.States.Count == 0)
                return BadRequest("Workflow must have at least one state.");

            var initialStates = definition.States.Where(s => s.IsInitial).ToList();
            if (initialStates.Count != 1)
                return BadRequest("Workflow must have exactly one initial state.");

            // Check for duplicate state IDs
            if (definition.States.Select(s => s.Id).Distinct().Count() != definition.States.Count)
                return BadRequest("State IDs must be unique.");

            // Check for duplicate action IDs
            if (definition.Actions != null && definition.Actions.Select(a => a.Id).Distinct().Count() != definition.Actions.Count)
                return BadRequest("Action IDs must be unique.");

            // Check that all referenced states in actions exist
            if (definition.Actions != null)
            {
                var stateIds = definition.States.Select(s => s.Id).ToHashSet();
                foreach (var action in definition.Actions)
                {
                    if (!stateIds.Contains(action.ToState) || action.FromStates.Any(f => !stateIds.Contains(f)))
                        return BadRequest($"Action '{action.Name}' references unknown state(s).");
                }
            }

            // Add the workflow definition
            _repository.AddWorkflowDefinition(definition);
            return CreatedAtAction(nameof(GetWorkflowDefinition), new { id = definition.Id }, definition);
        }

        /// <summary>
        /// Retrieves a workflow definition by ID.
        /// </summary>
        /// <param name="id">The workflow definition ID.</param>
        /// <returns>The workflow definition or NotFound.</returns>
        [HttpGet("{id}")]
        public IActionResult GetWorkflowDefinition(string id)
        {
            var definition = _repository.GetWorkflowDefinition(id);
            if (definition == null)
                return NotFound();
            return Ok(definition);
        }
    }
} 