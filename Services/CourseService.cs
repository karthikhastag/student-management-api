using WebApplication1.Models;

namespace WebApplication1.Services;

public class CourseService : ICourseService
{
    private static List<Course> _courses = new();
    private static int _nextId = 1;

    static CourseService()
    {
        _courses = new()
        {
            new Course { Id = 1, Name = "ASP.NET Core", Description = "Learn ASP.NET Core web development", Credits = 3, InstructorId = 1 },
            new Course { Id = 2, Name = "C#", Description = "Master C# programming language", Credits = 4, InstructorId = 1 },
            new Course { Id = 3, Name = "Database Design", Description = "SQL and database design principles", Credits = 3, InstructorId = 2 }
        };
        _nextId = 4;
    }

    public List<Course> GetAll()
    {
        return _courses;
    }

    public Course? GetById(int id)
    {
        return _courses.FirstOrDefault(c => c.Id == id);
    }

    public Course Add(Course course)
    {
        course.Id = _nextId++;
        _courses.Add(course);
        return course;
    }

    public Course? Update(int id, Course course)
    {
        var existingCourse = GetById(id);
        if (existingCourse == null)
            return null;

        existingCourse.Name = course.Name;
        existingCourse.Description = course.Description;
        existingCourse.Credits = course.Credits;
        existingCourse.InstructorId = course.InstructorId;
        return existingCourse;
    }

    public bool Delete(int id)
    {
        var course = GetById(id);
        if (course == null)
            return false;

        _courses.Remove(course);
        return true;
    }
}
