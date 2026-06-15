using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IEnrollmentService
{
    List<Enrollment> GetAll();
    Enrollment? GetById(int id);
    Enrollment Add(Enrollment enrollment);
    Enrollment? Update(int id, Enrollment enrollment);
    bool Delete(int id);
    List<Enrollment> GetByStudentId(int studentId);
    List<Enrollment> GetByCourseId(int courseId);
}
