using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorsController : ControllerBase
{
    private readonly IInstructorService _instructorService;

    public InstructorsController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    [HttpGet]
    public ActionResult<List<InstructorDto>> GetAll()
    {
        var instructors = _instructorService.GetAll();
        return Ok(instructors.Select(MapToDto).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<InstructorDto> GetById(int id)
    {
        var instructor = _instructorService.GetById(id);
        if (instructor == null)
            return NotFound();

        return Ok(MapToDto(instructor));
    }

    [HttpPost]
    public ActionResult<InstructorDto> Create(CreateInstructorDto dto)
    {
        var instructor = new Instructor
        {
            Name = dto.Name,
            Email = dto.Email,
            Department = dto.Department
        };

        var created = _instructorService.Add(instructor);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToDto(created));
    }

    [HttpPut("{id}")]
    public ActionResult<InstructorDto> Update(int id, UpdateInstructorDto dto)
    {
        var instructor = new Instructor
        {
            Name = dto.Name,
            Email = dto.Email,
            Department = dto.Department
        };

        var updated = _instructorService.Update(id, instructor);
        if (updated == null)
            return NotFound();

        return Ok(MapToDto(updated));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = _instructorService.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }

    private static InstructorDto MapToDto(Instructor instructor)
    {
        return new InstructorDto
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Email = instructor.Email,
            Department = instructor.Department
        };
    }
}
