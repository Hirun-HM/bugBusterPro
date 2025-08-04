namespace BugBustersPro.API.DTOs
{
    public class ContactSubmissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? ProjectType { get; set; }
        public string? Budget { get; set; }
        public string? Timeline { get; set; }
        public bool IsRead { get; set; }
        public bool IsResolved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RespondedAt { get; set; }
        public string? AdminNotes { get; set; }
    }

    public class CreateContactSubmissionDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string? ProjectType { get; set; }
        public string? Budget { get; set; }
        public string? Timeline { get; set; }
    }

    public class UpdateContactSubmissionDto
    {
        public bool IsRead { get; set; }
        public bool IsResolved { get; set; }
        public string? AdminNotes { get; set; }
    }
}
