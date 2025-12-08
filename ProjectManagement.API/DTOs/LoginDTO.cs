namespace ProjectManagement.API.DTOs
{
    /// <summary>
    /// data transfer object for logging in
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// Login user name
        /// </summary>
        public string Username { get; set; } = default!;
        /// <summary>
        /// Login Password
        /// </summary>
        public string Password { get; set; } = default!;
    }
}
