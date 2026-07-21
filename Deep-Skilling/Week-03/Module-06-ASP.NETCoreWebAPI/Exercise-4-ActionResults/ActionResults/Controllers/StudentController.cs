using Microsoft.AspNetCore.Mvc;
using ActionResults.Models;

namespace ActionResults.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Barnabas", Course = "CSE" },
            new Student { Id = 2, Name = "Rahul", Course = "ECE" }
        };

        // GET : api/student
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        // GET : api/student/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST : api/student
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                return BadRequest("Student Name is required.");

            students.Add(student);

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }
    }
}