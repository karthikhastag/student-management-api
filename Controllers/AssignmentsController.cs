using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet]
    public ActionResult<List<AssignmentDto>> GetAll()
    {
        var assignments = _assignmentService.GetAll();
        return Ok(assignments.Select(MapToDto).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<AssignmentDto> GetById(int id)
    {
        var assignment = _assignmentService.GetById(id);
        if (assignment == null)
            return NotFound();

        return Ok(MapToDto(assignment));
    }

    [HttpGet("course/{courseId}")]
    public ActionResult<List<AssignmentDto>> GetByCourseId(int courseId)
    {
        var assignments = _assignmentService.GetByCourseId(courseId);
        return Ok(assignments.Select(MapToDto).ToList());
    }

    [HttpPost]
    public ActionResult<AssignmentDto> Create(CreateAssignmentDto dto)
    {
        var assignment = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            CourseId = dto.CourseId,
            DueDate = dto.DueDate,
            MaxPoints = dto.MaxPoints
        };

        var created = _assignmentService.Add(assignment);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public ActionResult<AssignmentDto> Update(int id, UpdateAssignmentDto dto)
    {
        var assignment = new Assignment
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            MaxPoints = dto.MaxPoints
        };

        var updated = _assignmentService.Update(id, assignment);
        if (updated == null)
            return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _assignmentService.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    private static AssignmentDto MapToDto(Assignment assignment)
    {
        return new AssignmentDto
        {
            Id = assignment.Id,
            Title = assignment.Title,
            Description = assignment.Description,
            CourseId = assignment.CourseId,
            DueDate = assignment.DueDate,
            MaxPoints = assignment.MaxPoints
        };
    }
}
