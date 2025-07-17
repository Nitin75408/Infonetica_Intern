namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a state in a workflow (e.g., Draft, Approved).
    /// </summary>
    public class State
    {
        /// <summary>
        /// Unique identifier for the state.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Human-readable name for the state.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Indicates if this is the initial state of the workflow.
        /// </summary>
        public bool IsInitial { get; set; }

        /// <summary>
        /// Indicates if this is a final (terminal) state.
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// Indicates if this state is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Optional description for the state.
        /// </summary>
        public string? Description { get; set; }
    }
} 