using WebApplication1.Models;

namespace WebApplication1.Services;

public interface ICourseService
{
    List<Course> GetAll();
    Course? GetById(int id);
    Course Add(Course course);
    Course? Update(int id, Course course);
    bool Delete(int id);
}
