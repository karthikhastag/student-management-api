namespace WebApplication1.DTOs;

public class AssignmentDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public DateTime DueDate { get; set; }
    public int MaxPoints { get; set; }
}

public class CreateAssignmentDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CourseId { get; set; }
    public DateTime DueDate { get; set; }
    public int MaxPoints { get; set; }
}

public class UpdateAssignmentDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public int MaxPoints { get; set; }
}
