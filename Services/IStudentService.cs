using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IStudentService
{
    List<Student> GetAll();
    Student? GetById(int id);
    Student Add(Student student);
    Student? Update(int id, Student student);
    bool Delete(int id);
}
