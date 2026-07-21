using Microsoft.AspNetCore.Mvc;
using ModelValidationApi.Models;

namespace ModelValidationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            employees.Add(employee);

            return Ok(employee);
        }
    }
}