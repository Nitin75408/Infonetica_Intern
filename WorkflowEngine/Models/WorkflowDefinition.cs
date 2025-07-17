namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a workflow definition, which is a blueprint for a state machine.
    /// Contains the set of states and actions that define the workflow's behavior.
    /// </summary>
    /// <remarks>
    /// Each workflow must have a unique ID and exactly one initial state.
    /// </remarks>
    public class WorkflowDefinition
    {
        /// <summary>
        /// Gets or sets the unique identifier for the workflow definition.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the human-readable name for the workflow.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the collection of states in this workflow.
        /// </summary>
        public List<State> States { get; set; } = new List<State>();

        /// <summary>
        /// Gets or sets the collection of actions (transitions) in this workflow.
        /// </summary>
        public List<ActionTransition> Actions { get; set; } = new List<ActionTransition>();
    }
} 