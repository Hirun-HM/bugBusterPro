namespace BugBustersPro.API.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public string SolutionDescription { get; set; } = string.Empty;
        public string? ClientName { get; set; }
        public string? ProjectType { get; set; }
        public string? TechnologiesUsed { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? RepositoryUrl { get; set; }
        public int? TimeToSolveHours { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int CategoryId { get; set; }
        public ProjectCategoryDto? Category { get; set; }
    }

    public class CreateProjectDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public string SolutionDescription { get; set; } = string.Empty;
        public string? ClientName { get; set; }
        public string? ProjectType { get; set; }
        public string? TechnologiesUsed { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? RepositoryUrl { get; set; }
        public int? TimeToSolveHours { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int CategoryId { get; set; }
    }

    public class UpdateProjectDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProblemDescription { get; set; } = string.Empty;
        public string SolutionDescription { get; set; } = string.Empty;
        public string? ClientName { get; set; }
        public string? ProjectType { get; set; }
        public string? TechnologiesUsed { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
        public string? RepositoryUrl { get; set; }
        public int? TimeToSolveHours { get; set; }
        public bool IsFeatured { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
