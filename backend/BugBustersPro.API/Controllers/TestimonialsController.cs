using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugBustersPro.API.DTOs;
using BugBustersPro.API.Data;

namespace BugBustersPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly BugBustersDbContext _context;

        public TestimonialsController(BugBustersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TestimonialDto>), 200)]
        public async Task<ActionResult<IEnumerable<TestimonialDto>>> GetTestimonials()
        {
            var testimonials = await _context.Testimonials
                .Where(t => t.IsApproved)
                .ToListAsync();
                
            var testimonialDtos = testimonials.Select(t => new TestimonialDto
            {
                Id = t.Id,
                ClientName = t.ClientName,
                ClientCompany = t.ClientCompany,
                ClientPosition = t.ClientPosition,
                Content = t.Content,
                Rating = t.Rating,
                ClientImageUrl = t.ClientImageUrl,
                IsApproved = t.IsApproved,
                CreatedAt = t.CreatedAt,
                ProjectId = t.ProjectId
            });

            return Ok(testimonialDtos);
        }
    }
}
