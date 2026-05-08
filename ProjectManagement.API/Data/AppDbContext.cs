using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Data
{
    /// <summary>
    /// Application db context
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initalizes the constructor
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        /// <summary>
        /// Gets or sets projects
        /// </summary>
        public DbSet<Project> Projects { get; set; } = null!;

        /// <summary>
        /// Gets or sets skills
        /// </summary>
        public DbSet<Skill> Skills { get; set; } = null!;
        /// <summary>
        /// Gets or sets the profiles
        /// </summary>
        public DbSet<Profile> Profiles { get; set; } = null!;

        /// <summary>
        /// gets or sets the users
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;
    }

    /// <summary>
    /// static class to seed the data for our in memory collection
    /// </summary>
    public static class DbSeeder
    {
        /// <summary>
        /// void method that handles the seed
        /// </summary>
        /// <param name="db"></param>
        public static void Seed(AppDbContext db)
        {
            if (!db.Skills.Any())
            {
                db.Skills.AddRange(
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = ".NET" },
                    new Skill { Id = 3, Name = "SQL" }
                );
            }

            if (!db.Projects.Any())
            {
                db.Projects.AddRange(
                    new Project { Id = 1, Name = "Website Revamp", Description = "Frontend and backend refresh", IsFinished = false, Featured = false,Tech = ["blazor","C#","SQL"] ,StartDate = DateTime.Now.AddMonths(-3),EndDate = DateTime.Now.AddMonths(2)},
                    new Project { Id = 2, Name = "CI/CD Pipeline", Description = "Automate builds and deploys", IsFinished = false , Featured = true,Tech = ["c#"],StartDate = DateTime.Now.AddMonths(-5),EndDate = DateTime.Now.AddMonths(1)},
                    new Project { Id = 4, Name = "Skills Calculator", Description = "Gather around how many skills are being used within multiple teams", IsFinished = true , Featured = true,Tech = ["React", "TypeScript", "Vite","C#"],StartDate = DateTime.Now.AddMonths(-2),EndDate = DateTime.Now.AddDays(-2)},
                    new Project { Id = 5, Name = "student profiler", Description = "Student profiler app.", IsFinished = false , Featured = true,Tech = ["React", "TypeScript", "C#"],StartDate = DateTime.Now.AddMonths(-3),EndDate = DateTime.Now.AddMonths(2)},
                    new Project { Id = 6, Name = "Betsa", Description = "bets overview app.", IsFinished = true , Featured = false,Tech = ["Java", "Blazor"],StartDate = DateTime.Now.AddMonths(-4),EndDate = DateTime.Now.AddMonths(-2)},
                    new Project { Id = 7, Name = "myShopify", Description = "we'll be doing some small shopping here.", IsFinished = false , Featured = false,Tech = ["Angular", "TypeScript", "c#"],StartDate = DateTime.Now.AddMonths(-3),EndDate = DateTime.Now.AddMonths(3)},
                    new Project { Id = 8, Name = "Roborta", Description = "programming a bot to be my son's entertainment.", IsFinished = true , Featured = true,Tech = ["Python"],StartDate = DateTime.Now.AddMonths(-3),EndDate = DateTime.Now.AddDays(-9)},
                    new Project { Id = 9, Name = "ShopifyBO", Description = "Dashboard to monitor myShopify.", IsFinished = true , Featured = false,Tech = ["Blazor", "C#","SQL"],StartDate = DateTime.Now.AddMonths(-1),EndDate = DateTime.Now.AddDays(-4)},
                    new Project { Id = 10, Name = "Portfolio", Description = "Personal portfolio.", IsFinished = false , Featured = true,Tech = ["MudBlazor", "c#"],StartDate = DateTime.Now.AddMonths(-3),EndDate = DateTime.Now.AddMonths(2)}
                );
            }

            if (!db.Profiles.Any())
            {
                db.Profiles.Add(new Profile
                {
                    Id = 1,
                    FullName = "Sicelo Vilakazi",
                    Title = "Senior .NET Developer",
                    Bio = "Passionate about building resilient backend systems."
                });
            }
            if (!db.Users.Any())
            {
                var user = new User
                {
                    Username = "admin"
                };

                var hasher = new PasswordHasher<User>();
                user.PasswordHash = hasher.HashPassword(user, "Password123!");

                db.Users.Add(user);
            }

                db.SaveChanges();
        }
    }
}