namespace ProjectManagement.API.Models
{
    /// <summary>
    /// Project class
    /// </summary>
    public class Project
    {
        /// <summary>
        /// gets or sets the primary identifier
        /// </summary>
        public int Id { get; set; } 

        /// <summary>
        /// gets or sets the name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// gets or sets the description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        public bool Completed { get; set; } = false;
    }
}
