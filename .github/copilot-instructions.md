# BugBusters Pro - Copilot Instructions

<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

## Project Overview
BugBusters Pro is a full-stack web application for a bug-fixing company portfolio. The project consists of:

### Frontend (Next.js with TypeScript)
- **Framework**: Next.js 14+ with App Router
- **Language**: TypeScript
- **Styling**: Tailwind CSS
- **UI Components**: Modern, responsive design
- **Features**: Project portfolio, client testimonials, contact forms

### Backend (.NET Core Web API)
- **Framework**: .NET 8 Web API
- **Database**: PostgreSQL with Entity Framework Core
- **Authentication**: JWT-based authentication for admin panel
- **API Design**: RESTful endpoints

### Database
- **Database Name**: `solveerrors`
- **Owner**: `postgres`
- **Tables**: Projects, ProjectCategories, Testimonials, ContactSubmissions, Users

## Code Style Guidelines
- Use TypeScript strict mode
- Follow Next.js App Router conventions
- Use Tailwind CSS utility classes
- Implement responsive design patterns
- Use semantic HTML elements
- Follow REST API conventions for backend endpoints
- Use Entity Framework Core conventions for data access

## Business Requirements
- Display completed projects with before/after bug descriptions
- Show project categories (Web Development, Mobile Apps, Desktop Software)
- Admin panel for project management
- Client contact form for new project submissions
- Testimonials section
- Professional, trustworthy design aesthetic
- SEO-optimized pages

## Security Considerations
- Sanitize all user inputs
- Use parameterized queries
- Implement proper authentication/authorization
- Validate file uploads
- Use HTTPS in production
