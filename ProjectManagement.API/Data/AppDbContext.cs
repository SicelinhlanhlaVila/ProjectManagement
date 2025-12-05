using ProjectManagement.API.Models;
using Microsoft.EntityFrameworkCore;

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
        /// Gets or
        /// </summary>
        public DbSet<Profile> Profiles { get; set; } = null!;
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
                db.Skills.AddRange(new[]
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = ".NET" },
                    new Skill { Id = 3, Name = "SQL" }
                });
            }

            if (!db.Projects.Any())
            {
                db.Projects.AddRange(new[]
                {
                    new Project { Id = 1, Name = "Website Revamp", Description = "Frontend and backend refresh", Completed = false },
                    new Project { Id = 2, Name = "CI/CD Pipeline", Description = "Automate builds and deploys", Completed = true }
                });
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

            db.SaveChanges();
        }
    }
}