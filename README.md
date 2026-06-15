# 🎓 Student Management REST API

A comprehensive **ASP.NET Core 10.0** REST API for managing students, courses, instructors, enrollments, and assignments. Built with modern N-Tier architecture, full API documentation, and deployment-ready health checks.

[![GitHub Repository](https://img.shields.io/badge/GitHub-karthikhastag%2Fstudent--management--api-blue?logo=github)](https://github.com/karthikhastag/student-management-api)
![.NET Version](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 🚀 Features

- ✅ **Complete CRUD Operations** - Full Create, Read, Update, Delete functionality for all entities
- ✅ **N-Tier Architecture** - Separation of concerns: Controllers → Services → DTOs → Models
- ✅ **RESTful API Design** - Standard HTTP methods with proper status codes (200, 201, 204, 404, etc.)
- ✅ **Swagger/OpenAPI Documentation** - Interactive API documentation at `/swagger`
- ✅ **Dependency Injection** - Built-in .NET DI container for loose coupling
- ✅ **Health Check Endpoints** - 4 deployment-ready health probes (basic, detailed, liveness, readiness)
- ✅ **In-Memory Data** - Pre-seeded data for quick testing and demonstration
- ✅ **Entity Relationships** - Proper navigation properties and foreign keys (Student → Enrollment ← Course)
- ✅ **DTOs for API Contracts** - Request/response models separated from domain models
- ✅ **Comprehensive Documentation** - API docs, deployment guide, and test report included

---

## 📋 Tech Stack

- **Framework**: ASP.NET Core 10.0
- **Language**: C#
- **API Documentation**: Swagger/OpenAPI (Swashbuckle.AspNetCore 10.2.1)
- **Port**: 5129 (Development)
- **Environment**: Development with HTTPS redirection
- **Server**: Kestrel
- **Data Storage**: In-memory (ready for EF Core + Database)

---

## 📦 Project Structure

```
WebApplication1/
├── Controllers/              # HTTP request handlers
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   ├── InstructorsController.cs
│   ├── EnrollmentsController.cs
│   ├── AssignmentsController.cs
│   └── HealthController.cs
├── Services/                 # Business logic & CRUD operations
│   ├── IStudentService.cs
│   ├── StudentService.cs
│   ├── ICourseService.cs
│   ├── CourseService.cs
│   ├── InstructorService.cs
│   ├── EnrollmentService.cs
│   ├── AssignmentService.cs
│   └── IAssignmentService.cs
├── Models/                   # Domain entities
│   ├── Student.cs
│   ├── Course.cs
│   ├── Instructor.cs
│   ├── Enrollment.cs
│   └── Assignment.cs
├── DTOs/                     # Request/Response models
│   ├── StudentDto.cs
│   ├── CourseDto.cs
│   ├── InstructorDto.cs
│   ├── EnrollmentDto.cs
│   └── AssignmentDto.cs
├── Program.cs                # Application setup & DI configuration
├── appsettings.json          # Configuration settings
└── WebApplication1.csproj    # Project file

Documentation/
├── README.md                 # This file
├── API_DOCUMENTATION.md      # Detailed API reference
├── DEPLOYMENT_GUIDE.md       # Deployment instructions
└── TEST_REPORT.md           # Comprehensive testing guide
```

---

## 🏃 Quick Start

### Prerequisites
- **.NET SDK 10.0** or later
- **Visual Studio Code** or **Visual Studio 2022**
- **Git**

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone https://github.com/karthikhastag/student-management-api.git
   cd student-management-api
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```
   
   **Output:**
   ```
   Now listening on: http://localhost:5129
   Hosting environment: Development
   ```

4. **Access the API**
   - 📚 **Swagger UI**: http://localhost:5129/swagger
   - 🏥 **Health Check**: http://localhost:5129/api/health
   - 📋 **Health Details**: http://localhost:5129/api/health/detailed

---

## 📚 API Endpoints Overview

### Health Checks
```
GET  /api/health              - Basic health status
GET  /api/health/detailed     - Detailed system info
GET  /api/health/live         - Kubernetes liveness probe
GET  /api/health/ready        - Kubernetes readiness probe
```

### Students
```
GET    /api/students          - Get all students
GET    /api/students/{id}     - Get student by ID
POST   /api/students          - Create new student
PUT    /api/students/{id}     - Update student
DELETE /api/students/{id}     - Delete student
```

### Courses
```
GET    /api/courses           - Get all courses
GET    /api/courses/{id}      - Get course by ID
POST   /api/courses           - Create new course
PUT    /api/courses/{id}      - Update course
DELETE /api/courses/{id}      - Delete course
```

### Instructors
```
GET    /api/instructors       - Get all instructors
GET    /api/instructors/{id}  - Get instructor by ID
POST   /api/instructors       - Create new instructor
PUT    /api/instructors/{id}  - Update instructor
DELETE /api/instructors/{id}  - Delete instructor
```

### Enrollments
```
GET    /api/enrollments       - Get all enrollments
GET    /api/enrollments/{id}  - Get enrollment by ID
GET    /api/enrollments/student/{studentId}  - Get enrollments by student
GET    /api/enrollments/course/{courseId}    - Get enrollments by course
POST   /api/enrollments       - Enroll student in course
PUT    /api/enrollments/{id}  - Update enrollment (grade)
DELETE /api/enrollments/{id}  - Delete enrollment
```

### Assignments
```
GET    /api/assignments       - Get all assignments
GET    /api/assignments/{id}  - Get assignment by ID
GET    /api/assignments/course/{courseId}  - Get assignments by course
POST   /api/assignments       - Create new assignment
PUT    /api/assignments/{id}  - Update assignment
DELETE /api/assignments/{id}  - Delete assignment
```

---

## 📊 Seed Data

The API comes with pre-loaded data for immediate testing:

**Students** (3 records)
- Anil (anil@example.com)
- Rina (rina@example.com)
- Raj (raj@example.com)

**Courses** (3 records)
- ASP.NET Core (3 credits) - Instructor: Dr. John Smith
- C# (4 credits) - Instructor: Dr. John Smith
- Database Design (3 credits) - Instructor: Prof. Sarah Johnson

**Instructors** (3 records)
- Dr. John Smith (Computer Science)
- Prof. Sarah Johnson (Information Technology)
- Prof. Michael Brown (Computer Science)

**Enrollments** (4 records)
- Anil enrolled in 2 courses (grades: 95, 87)
- Rina enrolled in 2 courses (grades: 92, 88)

**Assignments** (3 records)
- REST API Design (100 points)
- OOP Principles (100 points)
- Database Schema Design (50 points)

---

## 🧪 Testing the API

### Option 1: Using Swagger UI (Easiest)
1. Open: http://localhost:5129/swagger
2. Click on any endpoint
3. Click **"Try it out"**
4. Click **"Execute"**
5. View the response

### Option 2: Using PowerShell
```powershell
# Get all students
Invoke-WebRequest -Uri http://localhost:5129/api/students -Method GET | Select-Object -ExpandProperty Content | ConvertFrom-Json | Format-Table

# Get health status
Invoke-WebRequest -Uri http://localhost:5129/api/health -Method GET | Select-Object -ExpandProperty Content | ConvertFrom-Json
```

### Option 3: Using cURL
```bash
# Get all courses
curl http://localhost:5129/api/courses

# Get health check
curl http://localhost:5129/api/health/detailed
```

---

## 📖 Documentation

- **[API_DOCUMENTATION.md](API_DOCUMENTATION.md)** - Detailed API reference with examples
- **[DEPLOYMENT_GUIDE.md](DEPLOYMENT_GUIDE.md)** - Step-by-step deployment instructions
- **[TEST_REPORT.md](TEST_REPORT.md)** - Comprehensive testing guide with 31+ test cases

---

## 🚢 Deployment

The application is ready for deployment using:

1. **Docker** - Containerized deployment
2. **Azure App Service** - Cloud hosting on Microsoft Azure
3. **IIS** - Windows Server deployment
4. **GitHub Actions** - Automated CI/CD pipeline

**See [DEPLOYMENT_GUIDE.md](DEPLOYMENT_GUIDE.md) for detailed instructions.**

---

## 🏗️ Architecture

### N-Tier Pattern
```
┌─────────────────────────────┐
│   Presentation Layer        │
│   (Controllers)             │
└──────────────┬──────────────┘
               │
┌──────────────▼──────────────┐
│   Business Logic Layer      │
│   (Services)                │
└──────────────┬──────────────┘
               │
┌──────────────▼──────────────┐
│   Data Transfer Layer       │
│   (DTOs)                    │
└──────────────┬──────────────┘
               │
┌──────────────▼──────────────┐
│   Data Layer                │
│   (Models)                  │
└─────────────────────────────┘
```

---

## 📝 Example Usage

### Creating a Student
```bash
curl -X POST http://localhost:5129/api/students \
  -H "Content-Type: application/json" \
  -d '{
    "name": "John Doe",
    "email": "john@example.com",
    "dateOfBirth": "2005-01-15"
  }'
```

### Getting All Courses
```bash
curl http://localhost:5129/api/courses
```

### Response Example
```json
[
  {
    "id": 1,
    "name": "ASP.NET Core",
    "description": "Learn modern web development",
    "credits": 3,
    "instructorId": 1
  }
]
```

---

## 🔧 Next Steps

1. **Add Database** - Integrate Entity Framework Core with SQL Server/PostgreSQL
2. **Authentication** - Implement JWT bearer token authentication
3. **Validation** - Add FluentValidation for input validation
4. **Logging** - Integrate Serilog for structured logging
5. **Testing** - Add xUnit tests and integration tests
6. **Performance** - Add caching and pagination

---

## 📜 License

This project is open source and available under the **MIT License**.

---

## 👤 Author

**Karthik Hastag**
- GitHub: [@karthikhastag](https://github.com/karthikhastag)
- Repository: [student-management-api](https://github.com/karthikhastag/student-management-api)

---

## 💡 Support

For issues, questions, or suggestions:
1. Check [API_DOCUMENTATION.md](API_DOCUMENTATION.md) for detailed information
2. Review [TEST_REPORT.md](TEST_REPORT.md) for testing examples
3. Open an issue on [GitHub Issues](https://github.com/karthikhastag/student-management-api/issues)

---

## 🎯 Status

- ✅ API Implementation: Complete
- ✅ Documentation: Complete
- ✅ Swagger Integration: Complete
- ✅ Health Checks: Complete
- ✅ Git Repository: Complete
- 🔄 Database Integration: Planned
- 🔄 Authentication: Planned
- 🔄 Unit Tests: Planned

---

**Happy coding! 🚀**
