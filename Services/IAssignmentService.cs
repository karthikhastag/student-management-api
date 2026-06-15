using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IAssignmentService
{
    List<Assignment> GetAll();
    Assignment? GetById(int id);
    Assignment Add(Assignment assignment);
    Assignment? Update(int id, Assignment assignment);
    bool Delete(int id);
    List<Assignment> GetByCourseId(int courseId);
}
