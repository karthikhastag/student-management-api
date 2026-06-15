using WebApplication1.Models;

namespace WebApplication1.Services;

public class AssignmentService : IAssignmentService
{
    private static List<Assignment> _assignments = new();
    private static int _nextId = 1;

    static AssignmentService()
    {
        _assignments = new()
        {
            new Assignment { Id = 1, Title = "Build a REST API", Description = "Create a REST API using ASP.NET Core", CourseId = 1, DueDate = DateTime.Now.AddDays(14), MaxPoints = 100 },
            new Assignment { Id = 2, Title = "Implement OOP Concepts", Description = "Write C# code demonstrating inheritance, polymorphism, and abstraction", CourseId = 2, DueDate = DateTime.Now.AddDays(7), MaxPoints = 100 },
            new Assignment { Id = 3, Title = "Database Schema Design", Description = "Design a normalized database schema for a given business scenario", CourseId = 3, DueDate = DateTime.Now.AddDays(21), MaxPoints = 50 }
        };
        _nextId = 4;
    }

    public List<Assignment> GetAll()
    {
        return _assignments;
    }

    public Assignment? GetById(int id)
    {
        return _assignments.FirstOrDefault(a => a.Id == id);
    }

    public Assignment Add(Assignment assignment)
    {
        assignment.Id = _nextId++;
        _assignments.Add(assignment);
        return assignment;
    }

    public Assignment? Update(int id, Assignment assignment)
    {
        var existingAssignment = GetById(id);
        if (existingAssignment == null)
            return null;

        existingAssignment.Title = assignment.Title;
        existingAssignment.Description = assignment.Description;
        existingAssignment.DueDate = assignment.DueDate;
        existingAssignment.MaxPoints = assignment.MaxPoints;
        return existingAssignment;
    }

    public bool Delete(int id)
    {
        var assignment = GetById(id);
        if (assignment == null)
            return false;

        _assignments.Remove(assignment);
        return true;
    }

    public List<Assignment> GetByCourseId(int courseId)
    {
        return _assignments.Where(a => a.CourseId == courseId).ToList();
    }
}
