using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugBustersPro.API.DTOs;
using BugBustersPro.API.Data;
using BugBustersPro.API.Models;

namespace BugBustersPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly BugBustersDbContext _context;

        public ContactController(BugBustersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContactSubmissionDto>), 200)]
        public async Task<ActionResult<IEnumerable<ContactSubmissionDto>>> GetContactSubmissions()
        {
            var submissions = await _context.ContactSubmissions.ToListAsync();
            var submissionDtos = submissions.Select(s => new ContactSubmissionDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
                Company = s.Company,
                Subject = s.Subject,
                Message = s.Message,
                ProjectType = s.ProjectType,
                Budget = s.Budget,
                Timeline = s.Timeline,
                IsRead = s.IsRead,
                IsResolved = s.IsResolved,
                CreatedAt = s.CreatedAt,
                RespondedAt = s.RespondedAt,
                AdminNotes = s.AdminNotes
            });

            return Ok(submissionDtos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContactSubmissionDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ContactSubmissionDto>> CreateContactSubmission(CreateContactSubmissionDto submissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submission = new ContactSubmission
            {
                Name = submissionDto.Name,
                Email = submissionDto.Email,
                Phone = submissionDto.Phone,
                Company = submissionDto.Company,
                Subject = submissionDto.Subject,
                Message = submissionDto.Message,
                ProjectType = submissionDto.ProjectType,
                Budget = submissionDto.Budget,
                Timeline = submissionDto.Timeline
            };

            _context.ContactSubmissions.Add(submission);
            await _context.SaveChangesAsync();

            var resultDto = new ContactSubmissionDto
            {
                Id = submission.Id,
                Name = submission.Name,
                Email = submission.Email,
                Phone = submission.Phone,
                Company = submission.Company,
                Subject = submission.Subject,
                Message = submission.Message,
                ProjectType = submission.ProjectType,
                Budget = submission.Budget,
                Timeline = submission.Timeline,
                IsRead = submission.IsRead,
                IsResolved = submission.IsResolved,
                CreatedAt = submission.CreatedAt,
                RespondedAt = submission.RespondedAt,
                AdminNotes = submission.AdminNotes
            };

            return CreatedAtAction(nameof(GetContactSubmissions), new { id = submission.Id }, resultDto);
        }
    }
}
