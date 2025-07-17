namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a record of an action executed on a workflow instance.
    /// </summary>
    public class ActionHistory
    {
        public string ActionId { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
} 