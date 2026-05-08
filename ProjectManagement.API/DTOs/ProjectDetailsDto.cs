namespace ProjectManagement.API.DTOs
{
    public class ProjectDetailsDto
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
        public bool Featured { get; set; } = false;

        /// <summary>
        /// list of all the tech used in the project
        /// </summary>
        public string[] Tech { get; set; }

        /// <summary>
        /// details of the project
        /// </summary>
        public string? Details { get; set; }

    }
}
