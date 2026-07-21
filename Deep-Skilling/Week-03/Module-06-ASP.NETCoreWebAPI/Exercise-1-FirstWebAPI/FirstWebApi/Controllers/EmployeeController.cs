using Microsoft.AspNetCore.Mvc;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Barnabas",
                    Department = "IT",
                    Salary = 50000
                },
                new Employee
                {
                    Id = 2,
                    Name = "Rahul",
                    Department = "HR",
                    Salary = 40000
                }
            };

            return Ok(employees);
        }
    }
}