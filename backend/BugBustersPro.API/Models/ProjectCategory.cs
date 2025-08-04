using System.ComponentModel.DataAnnotations;

namespace BugBustersPro.API.Models
{
    public class ProjectCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? IconClass { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
