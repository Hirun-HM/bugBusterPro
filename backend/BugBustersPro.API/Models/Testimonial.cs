using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugBustersPro.API.Models
{
    public class Testimonial
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? ClientCompany { get; set; }

        [MaxLength(100)]
        public string? ClientPosition { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; } = 5;

        [MaxLength(500)]
        public string? ClientImageUrl { get; set; }

        public bool IsApproved { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional foreign key to Project
        public int? ProjectId { get; set; }

        // Navigation property
        [ForeignKey("ProjectId")]
        public virtual Project? Project { get; set; }
    }
}
