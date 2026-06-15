using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IInstructorService
{
    List<Instructor> GetAll();
    Instructor? GetById(int id);
    Instructor Add(Instructor instructor);
    Instructor? Update(int id, Instructor instructor);
    bool Delete(int id);
}
