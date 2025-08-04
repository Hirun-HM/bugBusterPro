namespace BugBustersPro.API.DTOs
{
    public class ProjectCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? IconClass { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectCount { get; set; }
    }

    public class CreateProjectCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? IconClass { get; set; }
    }

    public class UpdateProjectCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? IconClass { get; set; }
    }
}
