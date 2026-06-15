# Student Management API Documentation

## 📚 Overview

A complete **ASP.NET Core 10.0 REST API** for managing an educational system with students, courses, instructors, enrollments, and assignments.

---

## 🏗️ Project Structure

```
WebApplication1/
├── Controllers/           # HTTP request handlers
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   ├── InstructorsController.cs
│   ├── EnrollmentsController.cs
│   ├── AssignmentsController.cs
│   └── HealthController.cs
│
├── Models/               # Data models/entities
│   ├── Student.cs
│   ├── Course.cs
│   ├── Instructor.cs
│   ├── Enrollment.cs
│   └── Assignment.cs
│
├── Services/            # Business logic layer
│   ├── IStudentService.cs & StudentService.cs
│   ├── ICourseService.cs & CourseService.cs
│   ├── IInstructorService.cs & InstructorService.cs
│   ├── IEnrollmentService.cs & EnrollmentService.cs
│   └── IAssignmentService.cs & AssignmentService.cs
│
├── DTOs/               # Data Transfer Objects
│   ├── StudentDto.cs
│   ├── CourseDto.cs
│   ├── InstructorDto.cs
│   ├── EnrollmentDto.cs
│   └── AssignmentDto.cs
│
├── Program.cs         # Application startup configuration
├── WebApplication1.http  # Testing endpoints (VS Code)
└── WebApplication1.csproj

```

---

## 🚀 Getting Started

### Prerequisites
- .NET 10.0 SDK installed
- Visual Studio Code or Visual Studio

### Installation & Running

```bash
# Navigate to project directory
cd e:\dontnet-project\WebApplication1

# Restore packages
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

The API will start on: `http://localhost:5129`

---

## 📖 API Endpoints

### **1. Students** (`/api/students`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/students` | Get all students |
| GET | `/api/students/{id}` | Get student by ID |
| POST | `/api/students` | Create new student |
| PUT | `/api/students/{id}` | Update student |
| DELETE | `/api/students/{id}` | Delete student |

**Sample Request (POST):**
```json
{
  "name": "John Doe",
  "email": "john@example.com",
  "dateOfBirth": "2000-01-15"
}
```

**Sample Response:**
```json
{
  "id": 4,
  "name": "John Doe",
  "email": "john@example.com",
  "dateOfBirth": "2000-01-15T00:00:00"
}
```

---

### **2. Courses** (`/api/courses`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/courses` | Get all courses |
| GET | `/api/courses/{id}` | Get course by ID |
| POST | `/api/courses` | Create new course |
| PUT | `/api/courses/{id}` | Update course |
| DELETE | `/api/courses/{id}` | Delete course |

**Sample Request (POST):**
```json
{
  "name": "Advanced C#",
  "description": "Learn advanced C# concepts",
  "credits": 4,
  "instructorId": 1
}
```

---

### **3. Instructors** (`/api/instructors`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/instructors` | Get all instructors |
| GET | `/api/instructors/{id}` | Get instructor by ID |
| POST | `/api/instructors` | Create new instructor |
| PUT | `/api/instructors/{id}` | Update instructor |
| DELETE | `/api/instructors/{id}` | Delete instructor |

---

### **4. Enrollments** (`/api/enrollments`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/enrollments` | Get all enrollments |
| GET | `/api/enrollments/{id}` | Get enrollment by ID |
| GET | `/api/enrollments/student/{studentId}` | Get student's enrollments |
| GET | `/api/enrollments/course/{courseId}` | Get course enrollments |
| POST | `/api/enrollments` | Create enrollment |
| PUT | `/api/enrollments/{id}` | Update enrollment (grade) |
| DELETE | `/api/enrollments/{id}` | Delete enrollment |

**Sample Request (POST):**
```json
{
  "studentId": 1,
  "courseId": 1
}
```

---

### **5. Assignments** (`/api/assignments`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/assignments` | Get all assignments |
| GET | `/api/assignments/{id}` | Get assignment by ID |
| GET | `/api/assignments/course/{courseId}` | Get course assignments |
| POST | `/api/assignments` | Create assignment |
| PUT | `/api/assignments/{id}` | Update assignment |
| DELETE | `/api/assignments/{id}` | Delete assignment |

---

### **6. Health** (`/api/health`)

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/health` | Check API health status |

**Response:**
```json
{
  "status": "Healthy",
  "timestamp": "2026-06-15T04:44:07.1963984Z",
  "service": "Student Management API",
  "version": "1.0.0"
}
```

---

## 🧪 Testing the API

### **Method 1: Swagger UI (Interactive)**
1. Start the application: `dotnet run`
2. Navigate to: `http://localhost:5129/swagger`
3. Click on any endpoint
4. Click "Try it out"
5. Enter parameters/body
6. Click "Execute"

### **Method 2: Browser (GET requests only)**
```
http://localhost:5129/api/students
http://localhost:5129/api/courses
http://localhost:5129/api/health
```

### **Method 3: VS Code REST Client**
- Open `WebApplication1.http`
- Click "Send Request" above any endpoint

### **Method 4: PowerShell/Terminal**
```powershell
# Get all students
Invoke-WebRequest -Uri http://localhost:5129/api/students -UseBasicParsing

# Get specific student
Invoke-WebRequest -Uri http://localhost:5129/api/students/1 -UseBasicParsing

# Create new student
$body = @{
    name = "Jane Smith"
    email = "jane@example.com"
    dateOfBirth = "2001-06-20"
} | ConvertTo-Json

Invoke-WebRequest -Uri http://localhost:5129/api/students `
    -Method POST `
    -ContentType "application/json" `
    -Body $body -UseBasicParsing
```

---

## 📊 Data Models

### **Student**
```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}
```

### **Course**
```csharp
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Credits { get; set; }
    public int InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}
```

### **Instructor**
```csharp
public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public List<Course> Courses { get; set; }
}
```

### **Enrollment**
```csharp
public class Enrollment
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public decimal? Grade { get; set; }
}
```

### **Assignment**
```csharp
public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CourseId { get; set; }
    public DateTime DueDate { get; set; }
    public int MaxPoints { get; set; }
}
```

---

## 🔄 Architecture Pattern

**N-Tier Architecture with Dependency Injection:**

```
┌─────────────────────────────┐
│   Presentation Layer        │
│    (Controllers)            │
└──────────────┬──────────────┘
               ↓
┌─────────────────────────────┐
│   Business Logic Layer      │
│    (Services)               │
└──────────────┬──────────────┘
               ↓
┌─────────────────────────────┐
│   Data Transfer Layer       │
│    (DTOs)                   │
└──────────────┬──────────────┘
               ↓
┌─────────────────────────────┐
│   Data Layer                │
│    (Models)                 │
└─────────────────────────────┘
```

---

## 📦 Seed Data

The API comes pre-loaded with sample data:

**Students:**
- Anil (anil@example.com)
- Rina (rina@example.com)
- Raj (raj@example.com)

**Courses:**
- ASP.NET Core (3 credits, Instructor: Dr. John Smith)
- C# (4 credits, Instructor: Dr. John Smith)
- Database Design (3 credits, Instructor: Prof. Sarah Johnson)

**Instructors:**
- Dr. John Smith (Computer Science)
- Prof. Sarah Johnson (Information Technology)
- Dr. Mike Chen (Computer Science)

**Enrollments:**
- Anil enrolled in ASP.NET Core (Grade: 95)
- Anil enrolled in C#
- Rina enrolled in ASP.NET Core (Grade: 87)
- Rina enrolled in Database Design

**Assignments:**
- Build a REST API (ASP.NET Core course, 100 points)
- Implement OOP Concepts (C# course, 100 points)
- Database Schema Design (Database Design course, 50 points)

---

## 🔧 Configuration

### **Program.cs Key Configuration:**

```csharp
// Swagger setup
builder.Services.AddSwaggerGen();

// Register all services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();

// Middleware configuration
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
    options.RoutePrefix = "swagger";
});

app.MapControllers();
```

---

## 📝 HTTP Status Codes

| Code | Meaning | Example |
|------|---------|---------|
| 200 | OK | Successful GET/PUT request |
| 201 | Created | Successful POST request |
| 204 | No Content | Successful DELETE request |
| 400 | Bad Request | Invalid input data |
| 404 | Not Found | Resource doesn't exist |
| 500 | Internal Server Error | Server error |

---

## 🔐 Future Enhancements

- [ ] Add JWT Authentication
- [ ] Add Input Validation (FluentValidation)
- [ ] Add Database (Entity Framework Core)
- [ ] Add Logging (Serilog)
- [ ] Add Unit Tests (xUnit)
- [ ] Add CORS Support
- [ ] Add Rate Limiting
- [ ] Add Caching (Redis)
- [ ] Add API Versioning
- [ ] Deploy to Azure/AWS

---

## 🛠️ Troubleshooting

### **Port Already in Use**
If port 5129 is already in use, check `launchSettings.json` and change the port.

### **Swagger Not Loading**
- Make sure you're on `http://localhost:5129/swagger` (not `/swagger/ui`)
- Check that the server is running
- Clear browser cache

### **CORS Errors**
Add CORS in Program.cs:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

app.UseCors("AllowAll");
```

---

## 📚 File Descriptions

| File | Purpose |
|------|---------|
| `Program.cs` | Application entry point and configuration |
| `WebApplication1.http` | REST Client requests for testing |
| `WebApplication1.csproj` | Project configuration and dependencies |
| `appsettings.json` | Application settings |
| `appsettings.Development.json` | Development-specific settings |

---

## 🚀 Quick Commands

```bash
# Build project
dotnet build

# Run project
dotnet run

# Run with watch (auto-reload)
dotnet watch run

# Add NuGet package
dotnet add package <PackageName>

# Clean build artifacts
dotnet clean

# Run tests (if added)
dotnet test
```

---

## 📞 Support

For issues or questions about the API, check:
1. Swagger documentation at `/swagger`
2. Controller code in `/Controllers`
3. Service implementation in `/Services`
4. Models definition in `/Models`

---

**Last Updated:** June 15, 2026  
**Version:** 1.0.0  
**Framework:** .NET 10.0

