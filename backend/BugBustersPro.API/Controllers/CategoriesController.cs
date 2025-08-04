using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugBustersPro.API.DTOs;
using BugBustersPro.API.Data;

namespace BugBustersPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly BugBustersDbContext _context;

        public CategoriesController(BugBustersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectCategoryDto>), 200)]
        public async Task<ActionResult<IEnumerable<ProjectCategoryDto>>> GetCategories()
        {
            var categories = await _context.ProjectCategories.ToListAsync();
            
            var categoryDtos = categories.Select(c => new ProjectCategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            });

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectCategoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectCategoryDto>> GetCategory(int id)
        {
            var category = await _context.ProjectCategories.FindAsync(id);
            
            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new ProjectCategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return Ok(categoryDto);
        }
    }
}
