using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll()
    {
        var courses = _courseService.GetAll();
        return Ok(courses.Select(MapToDto).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<CourseDto> GetById(int id)
    {
        var course = _courseService.GetById(id);
        if (course == null)
            return NotFound();

        return Ok(MapToDto(course));
    }

    [HttpPost]
    public ActionResult<CourseDto> Create(CreateCourseDto dto)
    {
        var course = new Course
        {
            Name = dto.Name,
            Description = dto.Description,
            Credits = dto.Credits,
            InstructorId = dto.InstructorId
        };

        var created = _courseService.Add(course);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public ActionResult<CourseDto> Update(int id, UpdateCourseDto dto)
    {
        var course = new Course
        {
            Name = dto.Name,
            Description = dto.Description,
            Credits = dto.Credits,
            InstructorId = dto.InstructorId
        };

        var updated = _courseService.Update(id, course);
        if (updated == null)
            return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _courseService.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    private static CourseDto MapToDto(Course course)
    {
        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description,
            Credits = course.Credits,
            InstructorId = course.InstructorId
        };
    }
}
