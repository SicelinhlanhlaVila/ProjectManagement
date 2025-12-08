namespace ProjectManagement.API.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Get's or sets the Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string Username { get; set; } = default!;
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string PasswordHash { get; set; } = default!;
    }
}
