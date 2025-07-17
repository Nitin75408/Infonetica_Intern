namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents an action (transition) that moves an instance from one state to another.
    /// </summary>
    public class ActionTransition
    {
        /// <summary>
        /// Unique identifier for the action.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Human-readable name for the action.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indicates if this action is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// List of state IDs from which this action can be executed.
        /// </summary>
        public List<string> FromStates { get; set; } = new List<string>();

        /// <summary>
        /// The state ID to which this action transitions.
        /// </summary>
        public string ToState { get; set; } = string.Empty;
    }
} 