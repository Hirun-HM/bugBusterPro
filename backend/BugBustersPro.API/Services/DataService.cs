using BugBustersPro.API.Models;

namespace BugBustersPro.API.Services
{
    public interface IDataService
    {
        Task<List<Project>> GetProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
        Task<List<ProjectCategory>> GetCategoriesAsync();
        Task<List<Testimonial>> GetTestimonialsAsync();
        Task<List<ContactSubmission>> GetContactSubmissionsAsync();
        Task<ContactSubmission> AddContactSubmissionAsync(ContactSubmission submission);
    }

    public class InMemoryDataService : IDataService
    {
        private static readonly List<ProjectCategory> _categories = new()
        {
            new() { Id = 1, Name = "Web Development", Description = "Frontend and backend web applications" },
            new() { Id = 2, Name = "Mobile Apps", Description = "iOS and Android mobile applications" },
            new() { Id = 3, Name = "Desktop Software", Description = "Windows, Mac, and Linux desktop applications" }
        };

        private static readonly List<Project> _projects = new()
        {
            new()
            {
                Id = 1,
                Title = "E-commerce Cart Bug Fix",
                Description = "Fixed critical shopping cart calculation error that was causing incorrect totals",
                ProblemDescription = "The shopping cart was calculating incorrect totals when users applied discount codes. The bug occurred when multiple discount codes were applied simultaneously, causing the system to compound discounts incorrectly and sometimes resulting in negative totals.",
                SolutionDescription = "Implemented a robust discount calculation system with proper order of operations. Added validation to prevent discount stacking issues and implemented comprehensive unit tests to ensure accurate calculations across all scenarios.",
                TechnologiesUsed = "React, Node.js, MongoDB",
                CompletedAt = DateTime.Now.AddDays(-30),
                ImageUrl = "",
                CategoryId = 1,
                Category = _categories[0]
            },
            new()
            {
                Id = 2,
                Title = "Mobile App Crash Fix",
                Description = "Resolved memory leak causing app crashes on iOS devices",
                ProblemDescription = "Users reported frequent app crashes on iOS devices, particularly after using the app for extended periods. Investigation revealed a memory leak in the image caching system that was causing the app to consume excessive memory.",
                SolutionDescription = "Refactored the image caching mechanism to properly release unused memory. Implemented automatic cache cleanup and optimized image loading to reduce memory footprint. Added memory monitoring to prevent future leaks.",
                TechnologiesUsed = "Swift, UIKit, Core Data",
                CompletedAt = DateTime.Now.AddDays(-15),
                ImageUrl = "",
                CategoryId = 2,
                Category = _categories[1]
            },
            new()
            {
                Id = 3,
                Title = "Database Performance Fix",
                Description = "Optimized slow database queries causing timeout errors",
                ProblemDescription = "The application was experiencing frequent database timeout errors during peak usage. Users reported slow loading times and occasional system unavailability. Investigation showed poorly optimized queries causing bottlenecks.",
                SolutionDescription = "Analyzed and optimized critical database queries, added proper indexing, and implemented query result caching. Reduced average query response time by 85% and eliminated timeout errors.",
                TechnologiesUsed = "PostgreSQL, Python, Django",
                CompletedAt = DateTime.Now.AddDays(-7),
                ImageUrl = "",
                CategoryId = 1,
                Category = _categories[0]
            }
        };

        private static readonly List<Testimonial> _testimonials = new()
        {
            new()
            {
                Id = 1,
                ClientName = "Sarah Johnson",
                ClientCompany = "TechStart Solutions",
                Content = "BugBusters Pro saved our product launch! They quickly identified and fixed a critical payment processing bug that could have cost us thousands in lost sales.",
                Rating = 5,
                IsApproved = true,
                CreatedAt = DateTime.Now.AddDays(-20)
            },
            new()
            {
                Id = 2,
                ClientName = "Mike Chen",
                ClientCompany = "MobileFirst Inc",
                Content = "Outstanding service! The team not only fixed our app crash issue but also provided detailed documentation and suggestions for preventing similar issues in the future.",
                Rating = 5,
                IsApproved = true,
                CreatedAt = DateTime.Now.AddDays(-10)
            },
            new()
            {
                Id = 3,
                ClientName = "Emily Rodriguez",
                ClientCompany = "DataFlow Systems",
                Content = "Professional, fast, and effective. They turned our database nightmare into a smooth-running system. Highly recommended for any performance issues.",
                Rating = 5,
                IsApproved = true,
                CreatedAt = DateTime.Now.AddDays(-5)
            }
        };

        private static readonly List<ContactSubmission> _contactSubmissions = new();

        public Task<List<Project>> GetProjectsAsync()
        {
            return Task.FromResult(_projects);
        }

        public Task<Project?> GetProjectByIdAsync(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(project);
        }

        public Task<List<ProjectCategory>> GetCategoriesAsync()
        {
            return Task.FromResult(_categories);
        }

        public Task<List<Testimonial>> GetTestimonialsAsync()
        {
            return Task.FromResult(_testimonials);
        }

        public Task<List<ContactSubmission>> GetContactSubmissionsAsync()
        {
            return Task.FromResult(_contactSubmissions);
        }

        public Task<ContactSubmission> AddContactSubmissionAsync(ContactSubmission submission)
        {
            submission.Id = _contactSubmissions.Count + 1;
            submission.CreatedAt = DateTime.Now;
            _contactSubmissions.Add(submission);
            return Task.FromResult(submission);
        }
    }
}
