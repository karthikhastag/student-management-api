using WebApplication1.Models;

namespace WebApplication1.Services;

public class InstructorService : IInstructorService
{
    private static List<Instructor> _instructors = new();
    private static int _nextId = 1;

    static InstructorService()
    {
        _instructors = new()
        {
            new Instructor { Id = 1, Name = "Dr. John Smith", Email = "john.smith@university.edu", Department = "Computer Science" },
            new Instructor { Id = 2, Name = "Prof. Sarah Johnson", Email = "sarah.johnson@university.edu", Department = "Information Technology" },
            new Instructor { Id = 3, Name = "Dr. Mike Chen", Email = "mike.chen@university.edu", Department = "Computer Science" }
        };
        _nextId = 4;
    }

    public List<Instructor> GetAll()
    {
        return _instructors;
    }

    public Instructor? GetById(int id)
    {
        return _instructors.FirstOrDefault(i => i.Id == id);
    }

    public Instructor Add(Instructor instructor)
    {
        instructor.Id = _nextId++;
        _instructors.Add(instructor);
        return instructor;
    }

    public Instructor? Update(int id, Instructor instructor)
    {
        var existingInstructor = GetById(id);
        if (existingInstructor == null)
            return null;

        existingInstructor.Name = instructor.Name;
        existingInstructor.Email = instructor.Email;
        existingInstructor.Department = instructor.Department;
        return existingInstructor;
    }

    public bool Delete(int id)
    {
        var instructor = GetById(id);
        if (instructor == null)
            return false;

        _instructors.Remove(instructor);
        return true;
    }
}
