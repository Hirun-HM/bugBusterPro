using Microsoft.EntityFrameworkCore;
using BugBustersPro.API.Models;

namespace BugBustersPro.API.Data
{
    public class BugBustersDbContext : DbContext
    {
        public BugBustersDbContext(DbContextOptions<BugBustersDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ContactSubmission> ContactSubmissions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<ProjectCategory>().ToTable("ProjectCategories");
            modelBuilder.Entity<Testimonial>().ToTable("Testimonials");
            modelBuilder.Entity<ContactSubmission>().ToTable("ContactSubmissions");
            modelBuilder.Entity<User>().ToTable("Users");

            // Configure relationships
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Testimonial>()
                .HasOne(t => t.Project)
                .WithMany()
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(p => p.IsFeatured);

            modelBuilder.Entity<ContactSubmission>()
                .HasIndex(c => c.IsRead);

            // Seed data
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<ProjectCategory>().HasData(
                new ProjectCategory { Id = 1, Name = "Web Development", Description = "Website and web application bug fixes", IconClass = "fas fa-globe", CreatedAt = DateTime.UtcNow },
                new ProjectCategory { Id = 2, Name = "Mobile Apps", Description = "iOS and Android application debugging", IconClass = "fas fa-mobile-alt", CreatedAt = DateTime.UtcNow },
                new ProjectCategory { Id = 3, Name = "Desktop Software", Description = "Desktop application bug resolution", IconClass = "fas fa-desktop", CreatedAt = DateTime.UtcNow },
                new ProjectCategory { Id = 4, Name = "API Integration", Description = "API and backend service fixes", IconClass = "fas fa-code", CreatedAt = DateTime.UtcNow }
            );

            // Seed Sample Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "E-commerce Cart Bug Fix",
                    Description = "Fixed critical shopping cart functionality that was preventing customers from completing purchases.",
                    ProblemDescription = "Shopping cart items were disappearing when users navigated between pages, causing significant revenue loss.",
                    SolutionDescription = "Implemented proper session management and local storage fallback to maintain cart state across page navigation.",
                    ClientName = "TechStore Solutions",
                    ProjectType = "E-commerce Website",
                    TechnologiesUsed = "React, Node.js, MongoDB",
                    TimeToSolveHours = 8,
                    IsFeatured = true,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-30),
                    CompletedAt = DateTime.UtcNow.AddDays(-28)
                },
                new Project
                {
                    Id = 2,
                    Title = "Mobile App Crash Resolution",
                    Description = "Resolved critical crash issues affecting iOS users during app startup.",
                    ProblemDescription = "App was crashing on iOS devices running version 16+ due to deprecated API usage.",
                    SolutionDescription = "Updated deprecated APIs and implemented proper error handling for device compatibility.",
                    ClientName = "FitTrack Pro",
                    ProjectType = "Fitness Mobile App",
                    TechnologiesUsed = "Swift, iOS SDK",
                    TimeToSolveHours = 12,
                    IsFeatured = true,
                    CategoryId = 2,
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    CompletedAt = DateTime.UtcNow.AddDays(-18)
                }
            );

            // Seed Sample Testimonials
            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial
                {
                    Id = 1,
                    ClientName = "John Smith",
                    ClientCompany = "TechStore Solutions",
                    ClientPosition = "CTO",
                    Content = "BugBusters Pro saved our business! They quickly identified and fixed a critical cart bug that was costing us thousands in lost sales. Highly recommended!",
                    Rating = 5,
                    IsApproved = true,
                    ProjectId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-25)
                },
                new Testimonial
                {
                    Id = 2,
                    ClientName = "Sarah Johnson",
                    ClientCompany = "FitTrack Pro",
                    ClientPosition = "Product Manager",
                    Content = "Professional, fast, and effective. They resolved our iOS crash issues within 48 hours. Our app store ratings improved immediately.",
                    Rating = 5,
                    IsApproved = true,
                    ProjectId = 2,
                    CreatedAt = DateTime.UtcNow.AddDays(-15)
                }
            );
        }
    }
}
