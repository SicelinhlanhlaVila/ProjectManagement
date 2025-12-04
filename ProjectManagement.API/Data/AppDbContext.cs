using ProjectManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<Profile> Profiles { get; set; } = null!;
    }

    public static class DbSeeder
    {
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