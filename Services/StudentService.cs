using WebApplication1.Models;

namespace WebApplication1.Services;

public class StudentService : IStudentService
{
    private static List<Student> _students = new();
    private static int _nextId = 1;

    static StudentService()
    {
        _students = new()
        {
            new Student { Id = 1, Name = "Anil", Email = "anil@example.com", DateOfBirth = new DateTime(2002, 5, 15) },
            new Student { Id = 2, Name = "Rina", Email = "rina@example.com", DateOfBirth = new DateTime(2003, 8, 22) },
            new Student { Id = 3, Name = "Raj", Email = "raj@example.com", DateOfBirth = new DateTime(2002, 12, 10) }
        };
        _nextId = 4;
    }

    public List<Student> GetAll()
    {
        return _students;
    }

    public Student? GetById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public Student Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
        return student;
    }

    public Student? Update(int id, Student student)
    {
        var existingStudent = GetById(id);
        if (existingStudent == null)
            return null;

        existingStudent.Name = student.Name;
        existingStudent.Email = student.Email;
        existingStudent.DateOfBirth = student.DateOfBirth;
        return existingStudent;
    }

    public bool Delete(int id)
    {
        var student = GetById(id);
        if (student == null)
            return false;

        _students.Remove(student);
        return true;
    }
}
