using Microsoft.AspNetCore.Mvc;
using RoutingApi.Models;

namespace RoutingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new()
        {
            new Student { Id = 1, Name = "Barnabas", Course = "CSE", Age = 20 },
            new Student { Id = 2, Name = "Rahul", Course = "ECE", Age = 21 },
            new Student { Id = 3, Name = "Priya", Course = "IT", Age = 22 }
        };

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        // GET: api/student/1
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // GET: api/student/course/CSE
        [HttpGet("course/{course}")]
        public IActionResult GetStudentsByCourse(string course)
        {
            var result = students.Where(s => s.Course.Equals(course, StringComparison.OrdinalIgnoreCase));

            return Ok(result);
        }
    }
}