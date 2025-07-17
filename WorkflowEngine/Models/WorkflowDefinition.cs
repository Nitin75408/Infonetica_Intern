namespace WorkflowEngine.Models
{
    /// <summary>
    /// Represents a workflow definition (blueprint).
    /// </summary>
    public class WorkflowDefinition
    {
        /// <summary>
        /// Unique identifier for the workflow definition.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Human-readable name for the workflow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of states in this workflow.
        /// </summary>
        public List<State> States { get; set; }

        /// <summary>
        /// Collection of actions (transitions) in this workflow.
        /// </summary>
        public List<ActionTransition> Actions { get; set; }
    }
} 