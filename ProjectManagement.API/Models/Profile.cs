namespace ProjectManagement.API.Models
{
    /// <summary>
    /// profile class
    /// </summary>
    public class Profile
    {
        /// <summary>
        /// gets and sets the Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// gets and sets the full name
        /// </summary>
        public string FullName { get; set; } = string.Empty;
        /// <summary>
        /// gets and sets the title
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// gets and sets
        /// </summary>
        public string? Bio { get; set; }
    }
}
