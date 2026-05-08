namespace ProjectManagement.API.DTOs
{
    public class RecentlyCompletedProjectsDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string CompletedDate { get; set; }
    }
}
