namespace ProjectManagement.API.Models
{
    /// <summary>
    /// Skill class
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Gets or sets the primary identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the skill name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
