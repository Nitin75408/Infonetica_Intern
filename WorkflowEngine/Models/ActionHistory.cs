namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a record of an action executed on a workflow instance.
    /// Used to track the history of state transitions for an instance.
    /// </summary>
    /// <remarks>
    /// Each entry records the action performed and the timestamp of execution.
    /// </remarks>
    public class ActionHistory
    {
        /// <summary>
        /// Gets or sets the action ID that was executed.
        /// </summary>
        public string ActionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the timestamp when the action was executed.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
} 