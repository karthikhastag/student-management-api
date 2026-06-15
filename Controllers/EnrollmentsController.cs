using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public ActionResult<List<EnrollmentDto>> GetAll()
    {
        var enrollments = _enrollmentService.GetAll();
        return Ok(enrollments.Select(MapToDto).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<EnrollmentDto> GetById(int id)
    {
        var enrollment = _enrollmentService.GetById(id);
        if (enrollment == null)
            return NotFound();

        return Ok(MapToDto(enrollment));
    }

    [HttpGet("student/{studentId}")]
    public ActionResult<List<EnrollmentDto>> GetByStudentId(int studentId)
    {
        var enrollments = _enrollmentService.GetByStudentId(studentId);
        return Ok(enrollments.Select(MapToDto).ToList());
    }

    [HttpGet("course/{courseId}")]
    public ActionResult<List<EnrollmentDto>> GetByCourseId(int courseId)
    {
        var enrollments = _enrollmentService.GetByCourseId(courseId);
        return Ok(enrollments.Select(MapToDto).ToList());
    }

    [HttpPost]
    public ActionResult<EnrollmentDto> Create(CreateEnrollmentDto dto)
    {
        var enrollment = new Enrollment
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId
        };

        var created = _enrollmentService.Add(enrollment);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public ActionResult<EnrollmentDto> Update(int id, UpdateEnrollmentDto dto)
    {
        var enrollment = new Enrollment
        {
            Grade = dto.Grade
        };

        var updated = _enrollmentService.Update(id, enrollment);
        if (updated == null)
            return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _enrollmentService.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    private static EnrollmentDto MapToDto(Enrollment enrollment)
    {
        return new EnrollmentDto
        {
            Id = enrollment.Id,
            StudentId = enrollment.StudentId,
            CourseId = enrollment.CourseId,
            EnrollmentDate = enrollment.EnrollmentDate,
            Grade = enrollment.Grade
        };
    }
}
