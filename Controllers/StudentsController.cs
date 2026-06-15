using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public ActionResult<List<StudentDto>> GetAll()
    {
        var students = _studentService.GetAll();
        return Ok(students.Select(MapToDto).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<StudentDto> GetById(int id)
    {
        var student = _studentService.GetById(id);
        if (student == null)
            return NotFound();

        return Ok(MapToDto(student));
    }

    [HttpPost]
    public ActionResult<StudentDto> Create(CreateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            DateOfBirth = dto.DateOfBirth
        };

        var created = _studentService.Add(student);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public ActionResult<StudentDto> Update(int id, UpdateStudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Email = dto.Email,
            DateOfBirth = dto.DateOfBirth
        };

        var updated = _studentService.Update(id, student);
        if (updated == null)
            return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _studentService.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    private static StudentDto MapToDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            DateOfBirth = student.DateOfBirth
        };
    }
}
