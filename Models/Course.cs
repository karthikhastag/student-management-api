namespace WebApplication1.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Credits { get; set; }
    public int InstructorId { get; set; }
    public Instructor? Instructor { get; set; }
    public List<Enrollment> Enrollments { get; set; } = new();
}
