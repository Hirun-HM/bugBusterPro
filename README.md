# BugBusters Pro - Professional Bug Fixing Company Portfolio

A full-stack web application showcasing a professional bug-fixing company's portfolio. Built with Next.js frontend, .NET Core Web API backend, and PostgreSQL database.

## 🚀 Features

### Frontend (Next.js + TypeScript)
- **Modern Design**: Professional, responsive UI with Tailwind CSS
- **Project Portfolio**: Showcase of completed bug fixes with before/after descriptions
- **Client Testimonials**: Display customer feedback and ratings
- **Contact System**: Client inquiry form for new projects
- **Admin Dashboard**: Project and testimonial management (coming soon)
- **SEO Optimized**: Meta tags and structured data for better search visibility

### Backend (.NET Core Web API)
- **RESTful API**: Clean API design with OpenAPI/Swagger documentation
- **Database Integration**: PostgreSQL with Entity Framework Core
- **Project Management**: CRUD operations for projects, categories, and testimonials
- **Contact Handling**: Submission tracking and admin notifications
- **Authentication**: JWT-based authentication for admin features
- **CORS Enabled**: Frontend-backend communication support

### Database (PostgreSQL)
- **Database Name**: `solveerrors`
- **Tables**: Projects, ProjectCategories, Testimonials, ContactSubmissions, Users
- **Seeded Data**: Sample projects and testimonials for demonstration
- **Relationships**: Proper foreign key constraints and data integrity

## 🛠️ Tech Stack

### Frontend
- **Framework**: Next.js 14+ with App Router
- **Language**: TypeScript
- **Styling**: Tailwind CSS
- **Icons**: Lucide React
- **Build Tool**: Next.js built-in bundler

### Backend
- **Framework**: .NET 9 Web API
- **Database**: PostgreSQL 
- **ORM**: Entity Framework Core
- **Authentication**: JWT Bearer tokens
- **Documentation**: Swagger/OpenAPI
- **Hosting**: Can be deployed to Azure, AWS, or any cloud provider

### Database
- **PostgreSQL**: Production-ready relational database
- **Entity Framework**: Code-first migrations
- **Connection**: Configurable connection strings

## 📦 Project Structure

```
bugfix/
├── src/                          # Next.js frontend
│   ├── app/                      # App Router pages
│   │   ├── layout.tsx           # Root layout with navigation
│   │   ├── page.tsx             # Homepage
│   │   └── globals.css          # Global styles
│   └── components/              # Reusable React components
├── backend/                     # .NET Core backend
│   └── BugBustersPro.API/
│       ├── Controllers/         # API controllers
│       ├── Models/             # Data models
│       ├── DTOs/               # Data transfer objects
│       ├── Data/               # Database context
│       └── Program.cs          # Application entry point
├── public/                      # Static assets
└── README.md                    # This file
```

## 🚀 Getting Started

### Prerequisites
- **Node.js** 18+ 
- **.NET 9 SDK**
- **PostgreSQL** 12+
- **Git**

### Database Setup
1. Install PostgreSQL and create a database named `solveerrors`
2. Update the connection string in `backend/BugBustersPro.API/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=solveerrors;Username=postgres;Password=yourpassword"
     }
   }
   ```

### Backend Setup
1. Navigate to the backend directory:
   ```bash
   cd backend/BugBustersPro.API
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

The API will be available at `https://localhost:5001` with Swagger documentation at the root URL.

### Frontend Setup
1. Navigate to the project root:
   ```bash
   cd /path/to/bugfix
   ```

2. Install dependencies:
   ```bash
   npm install
   ```

3. Start the development server:
   ```bash
   npm run dev
   ```

The frontend will be available at `http://localhost:3000`.

## 📊 API Endpoints

### Projects
- `GET /api/projects` - Get all projects with filtering
- `GET /api/projects/{id}` - Get project by ID
- `POST /api/projects` - Create new project (requires auth)
- `PUT /api/projects/{id}` - Update project (requires auth)
- `DELETE /api/projects/{id}` - Delete project (requires auth)

### Categories
- `GET /api/categories` - Get all project categories
- `POST /api/categories` - Create new category (requires auth)

### Testimonials
- `GET /api/testimonials` - Get testimonials with filtering
- `POST /api/testimonials` - Submit new testimonial
- `PATCH /api/testimonials/{id}/approve` - Approve testimonial (requires auth)

### Contact
- `GET /api/contact` - Get contact submissions (requires auth)
- `POST /api/contact` - Submit contact form
- `PATCH /api/contact/{id}/mark-read` - Mark as read (requires auth)

## 🎨 Design Features

- **Professional Color Scheme**: Blue primary with gray accents
- **Responsive Design**: Mobile-first approach with Tailwind CSS
- **Modern Typography**: Clean, readable fonts
- **Interactive Elements**: Hover effects and smooth transitions
- **Loading States**: User-friendly loading indicators
- **Error Handling**: Graceful error messages and fallbacks

## 🔐 Security Features

- **Input Validation**: Server-side validation for all inputs
- **SQL Injection Protection**: Parameterized queries via Entity Framework
- **CORS Configuration**: Controlled cross-origin requests
- **JWT Authentication**: Secure admin authentication
- **Password Hashing**: Secure password storage (when user system is implemented)

## 🚀 Deployment

### Frontend (Vercel/Netlify)
1. Connect your repository to your preferred platform
2. Set build command: `npm run build`
3. Set output directory: `.next`

### Backend (Azure/AWS/Railway)
1. Configure environment variables
2. Set up PostgreSQL database
3. Deploy using container or direct deployment

### Database (PostgreSQL)
- Use managed PostgreSQL service (Azure Database, AWS RDS, etc.)
- Run migrations: `dotnet ef database update`

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/amazing-feature`
3. Commit changes: `git commit -m 'Add amazing feature'`
4. Push to branch: `git push origin feature/amazing-feature`
5. Open a Pull Request

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 📞 Contact

**BugBusters Pro** - Professional Bug Fixing Services
- Website: [Coming Soon]
- Email: contact@bugbusterspro.com
- Portfolio: Built with this very application!

---

*Built with ❤️ using Next.js, .NET Core, and PostgreSQL*
