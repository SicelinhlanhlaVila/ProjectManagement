using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.API.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Handles all operations related to accounts
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _db;

        private readonly IConfiguration _config;
        private readonly IPasswordHasher<Models.User> _hasher;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="config"></param>
        /// <param name="hasher"></param>
        public AccountService(AppDbContext db, IConfiguration config, IPasswordHasher<Models.User> hasher)
        {
            _db = db;
            _config = config;
            _hasher = hasher;
        }

        /// <summary>
        /// Used to authorize a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> AuthoriseUser(string username, string password)
        {
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return "Invalid Username";
            }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result == PasswordVerificationResult.Failed)
                return "Invalid username or password.";

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, user.Username) },
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
