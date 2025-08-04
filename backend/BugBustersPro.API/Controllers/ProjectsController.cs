using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BugBustersPro.API.DTOs;
using BugBustersPro.API.Data;

namespace BugBustersPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugBustersDbContext _context;

        public ProjectsController(BugBustersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProjectDto>), 200)]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _context.Projects
                .Include(p => p.Category)
                .ToListAsync();
                
            var projectDtos = projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ProblemDescription = p.ProblemDescription,
                SolutionDescription = p.SolutionDescription,
                ClientName = p.ClientName,
                ProjectType = p.ProjectType,
                TechnologiesUsed = p.TechnologiesUsed,
                ImageUrl = p.ImageUrl,
                ProjectUrl = p.ProjectUrl,
                RepositoryUrl = p.RepositoryUrl,
                TimeToSolveHours = p.TimeToSolveHours,
                IsFeatured = p.IsFeatured,
                CreatedAt = p.CreatedAt,
                CompletedAt = p.CompletedAt,
                CategoryId = p.CategoryId,
                Category = new ProjectCategoryDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name,
                    Description = p.Category.Description
                }
            });

            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
                
            if (project == null)
            {
                return NotFound();
            }

            var projectDto = new ProjectDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                ProblemDescription = project.ProblemDescription,
                SolutionDescription = project.SolutionDescription,
                ClientName = project.ClientName,
                ProjectType = project.ProjectType,
                TechnologiesUsed = project.TechnologiesUsed,
                ImageUrl = project.ImageUrl,
                ProjectUrl = project.ProjectUrl,
                RepositoryUrl = project.RepositoryUrl,
                TimeToSolveHours = project.TimeToSolveHours,
                IsFeatured = project.IsFeatured,
                CreatedAt = project.CreatedAt,
                CompletedAt = project.CompletedAt,
                CategoryId = project.CategoryId,
                Category = new ProjectCategoryDto
                {
                    Id = project.Category.Id,
                    Name = project.Category.Name,
                    Description = project.Category.Description
                }
            };

            return Ok(projectDto);
        }
    }
}
