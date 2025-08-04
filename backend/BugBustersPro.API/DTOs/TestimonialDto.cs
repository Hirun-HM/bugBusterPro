namespace BugBustersPro.API.DTOs
{
    public class TestimonialDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? ClientCompany { get; set; }
        public string? ClientPosition { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? ClientImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ProjectId { get; set; }
        public string? ProjectTitle { get; set; }
    }

    public class CreateTestimonialDto
    {
        public string ClientName { get; set; } = string.Empty;
        public string? ClientCompany { get; set; }
        public string? ClientPosition { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; } = 5;
        public string? ClientImageUrl { get; set; }
        public int? ProjectId { get; set; }
    }

    public class UpdateTestimonialDto
    {
        public string ClientName { get; set; } = string.Empty;
        public string? ClientCompany { get; set; }
        public string? ClientPosition { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string? ClientImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public int? ProjectId { get; set; }
    }
}
