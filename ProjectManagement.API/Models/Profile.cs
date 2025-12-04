namespace ProjectManagement.API.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Bio { get; set; }
    }
}
