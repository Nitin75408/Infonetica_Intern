namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a running instance of a workflow.
    /// </summary>
    public class WorkflowInstance
    {
        /// <summary>
        /// Unique identifier for the instance.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The workflow definition ID this instance is based on.
        /// </summary>
        public string WorkflowDefinitionId { get; set; }

        /// <summary>
        /// The current state ID of the instance.
        /// </summary>
        public string CurrentStateId { get; set; }

        /// <summary>
        /// The history of actions executed on this instance.
        /// </summary>
        public List<ActionHistory> History { get; set; } = new List<ActionHistory>();
    }
} 