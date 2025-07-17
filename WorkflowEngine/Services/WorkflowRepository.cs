using WorkflowEngine.Models;

namespace WorkflowEngine.Services
{
    /// <summary>
    /// In-memory repository for storing workflow definitions and instances.
    /// This class acts as a simple data store for the application.
    /// </summary>
    public class WorkflowRepository
    {
        // Static collections to store data in-memory.
        // These are shared across all requests and lost when the app restarts.

        /// <summary>
        /// Stores all workflow definitions, keyed by their unique ID.
        /// </summary>
        private static readonly Dictionary<string, WorkflowDefinition> _workflowDefinitions = new();

        /// <summary>
        /// Stores all workflow instances, keyed by their unique ID.
        /// </summary>
        private static readonly Dictionary<string, WorkflowInstance> _workflowInstances = new();

        /// <summary>
        /// Adds a new workflow definition.
        /// </summary>
        public void AddWorkflowDefinition(WorkflowDefinition definition)
        {
            _workflowDefinitions[definition.Id] = definition;
        }

        /// <summary>
        /// Retrieves a workflow definition by ID.
        /// </summary>
        public WorkflowDefinition? GetWorkflowDefinition(string id)
        {
            _workflowDefinitions.TryGetValue(id, out var definition);
            return definition;
        }

        /// <summary>
        /// Returns all workflow definitions.
        /// </summary>
        public IEnumerable<WorkflowDefinition> GetAllWorkflowDefinitions()
        {
            return _workflowDefinitions.Values;
        }

        /// <summary>
        /// Adds a new workflow instance.
        /// </summary>
        public void AddWorkflowInstance(WorkflowInstance instance)
        {
            _workflowInstances[instance.Id] = instance;
        }

        /// <summary>
        /// Retrieves a workflow instance by ID.
        /// </summary>
        public WorkflowInstance? GetWorkflowInstance(string id)
        {
            _workflowInstances.TryGetValue(id, out var instance);
            return instance;
        }

        /// <summary>
        /// Returns all workflow instances.
        /// </summary>
        public IEnumerable<WorkflowInstance> GetAllWorkflowInstances()
        {
            return _workflowInstances.Values;
        }

        /// <summary>
        /// Updates an existing workflow instance.
        /// </summary>
        public void UpdateWorkflowInstance(WorkflowInstance instance)
        {
            _workflowInstances[instance.Id] = instance;
        }
    }
} 