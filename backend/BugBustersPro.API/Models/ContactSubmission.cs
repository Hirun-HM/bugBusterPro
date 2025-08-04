using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugBustersPro.API.Models
{
    public class ContactSubmission
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Company { get; set; }

        [Required]
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "text")]
        public string Message { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? ProjectType { get; set; }

        [MaxLength(100)]
        public string? Budget { get; set; }

        [MaxLength(100)]
        public string? Timeline { get; set; }

        public bool IsRead { get; set; } = false;
        public bool IsResolved { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? RespondedAt { get; set; }

        [MaxLength(1000)]
        public string? AdminNotes { get; set; }
    }
}
