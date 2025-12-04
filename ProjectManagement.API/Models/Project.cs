namespace ProjectManagement.API.Models
{
    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool Completed { get; set; } = false;
    }
}
