using Microsoft.AspNetCore.Mvc;

namespace _2_api_with_db.Student;

[ApiController]
[Route("api/student")]
public class StudentsController(IStudentService studentService) : ControllerBase
{
    private readonly IStudentService _studentService = studentService;

    // GET: api/student
    [HttpGet]
    public IActionResult GetAllStudent()
    {
        return Ok(_studentService.GetAllStudents());
    }

    // GET: api/student/{id}
    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentService.GetStudentById(id);
        return student == null ? NotFound() : Ok(student);
    }

    // POST: api/student
    [HttpPost]
    public IActionResult AddStudent([FromBody] StudentDto student)
    {
        try
        {
            var createdStudent = _studentService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // PUT: api/student/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, [FromBody] StudentDto student)
    {
        try
        {
            var result = _studentService.UpdateStudent(id, student);

            return result == null ? NotFound() : Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    // DELETE: api/student/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var success = _studentService.DeleteStudent(id);
        return success ? NoContent() : NotFound();
    }
}