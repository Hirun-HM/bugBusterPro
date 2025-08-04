using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugBustersPro.API.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "text")]
        public string ProblemDescription { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "text")]
        public string SolutionDescription { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ClientName { get; set; }

        [MaxLength(100)]
        public string? ProjectType { get; set; }

        [MaxLength(200)]
        public string? TechnologiesUsed { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [MaxLength(200)]
        public string? ProjectUrl { get; set; }

        [MaxLength(200)]
        public string? RepositoryUrl { get; set; }

        public int? TimeToSolveHours { get; set; }

        public bool IsFeatured { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation property
        [ForeignKey("CategoryId")]
        public virtual ProjectCategory Category { get; set; } = null!;
    }
}
