namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents an action (transition) that moves a workflow instance from one state to another.
    /// Actions define the valid transitions in a workflow.
    /// </summary>
    /// <remarks>
    /// Each action must specify the source states (FromStates) and a single target state (ToState).
    /// Actions can be enabled or disabled to control their availability.
    /// </remarks>
    public class ActionTransition
    {
        /// <summary>
        /// Gets or sets the unique identifier for the action.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the human-readable name for the action.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this action is enabled and can be executed.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the list of state IDs from which this action can be executed.
        /// </summary>
        public List<string> FromStates { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the state ID to which this action transitions.
        /// </summary>
        public string ToState { get; set; } = string.Empty;
    }
} 