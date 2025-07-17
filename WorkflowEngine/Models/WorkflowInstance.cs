namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a running instance of a workflow.
    /// Tracks the current state and the history of actions performed.
    /// </summary>
    /// <remarks>
    /// Each instance is based on a workflow definition and maintains its own state and history.
    /// </remarks>
    public class WorkflowInstance
    {
        /// <summary>
        /// Gets or sets the unique identifier for the instance.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the workflow definition ID this instance is based on.
        /// </summary>
        public string WorkflowDefinitionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current state ID of the instance.
        /// </summary>
        public string CurrentStateId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the history of actions executed on this instance.
        /// </summary>
        public List<ActionHistory> History { get; set; } = new List<ActionHistory>();
    }
} 