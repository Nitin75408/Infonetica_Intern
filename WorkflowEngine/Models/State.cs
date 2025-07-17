namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a state within a workflow, such as 'Draft', 'Approved', or 'Rejected'.
    /// States are used to track the current status of a workflow instance.
    /// </summary>
    /// <remarks>
    /// Each workflow must have exactly one initial state (IsInitial = true).
    /// Final states (IsFinal = true) indicate the end of a workflow.
    /// </remarks>
    public class State
    {
        /// <summary>
        /// Gets or sets the unique identifier for the state.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the human-readable name for the state.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this state is the initial state of the workflow.
        /// </summary>
        public bool IsInitial { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this state is a final (terminal) state.
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this state is enabled and can be used in transitions.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets an optional description for the state.
        /// </summary>
        public string? Description { get; set; }
    }
} 