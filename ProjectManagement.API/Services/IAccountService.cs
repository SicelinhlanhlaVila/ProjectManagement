namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Handles all operations related to accounts
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// used to authorise a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> AuthoriseUser(string username, string password);
    }
}
