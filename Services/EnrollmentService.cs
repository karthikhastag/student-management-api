using WebApplication1.Models;

namespace WebApplication1.Services;

public class EnrollmentService : IEnrollmentService
{
    private static List<Enrollment> _enrollments = new();
    private static int _nextId = 1;

    static EnrollmentService()
    {
        _enrollments = new()
        {
            new Enrollment { Id = 1, StudentId = 1, CourseId = 1, EnrollmentDate = DateTime.Now.AddMonths(-3), Grade = 95 },
            new Enrollment { Id = 2, StudentId = 1, CourseId = 2, EnrollmentDate = DateTime.Now.AddMonths(-3), Grade = null },
            new Enrollment { Id = 3, StudentId = 2, CourseId = 1, EnrollmentDate = DateTime.Now.AddMonths(-2), Grade = 87 },
            new Enrollment { Id = 4, StudentId = 2, CourseId = 3, EnrollmentDate = DateTime.Now.AddMonths(-2), Grade = null }
        };
        _nextId = 5;
    }

    public List<Enrollment> GetAll()
    {
        return _enrollments;
    }

    public Enrollment? GetById(int id)
    {
        return _enrollments.FirstOrDefault(e => e.Id == id);
    }

    public Enrollment Add(Enrollment enrollment)
    {
        enrollment.Id = _nextId++;
        enrollment.EnrollmentDate = DateTime.Now;
        _enrollments.Add(enrollment);
        return enrollment;
    }

    public Enrollment? Update(int id, Enrollment enrollment)
    {
        var existingEnrollment = GetById(id);
        if (existingEnrollment == null)
            return null;

        existingEnrollment.Grade = enrollment.Grade;
        return existingEnrollment;
    }

    public bool Delete(int id)
    {
        var enrollment = GetById(id);
        if (enrollment == null)
            return false;

        _enrollments.Remove(enrollment);
        return true;
    }

    public List<Enrollment> GetByStudentId(int studentId)
    {
        return _enrollments.Where(e => e.StudentId == studentId).ToList();
    }

    public List<Enrollment> GetByCourseId(int courseId)
    {
        return _enrollments.Where(e => e.CourseId == courseId).ToList();
    }
}
