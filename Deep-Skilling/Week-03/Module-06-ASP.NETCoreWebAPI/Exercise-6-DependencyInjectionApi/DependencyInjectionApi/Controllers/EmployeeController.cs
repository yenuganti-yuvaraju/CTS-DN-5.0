using Microsoft.AspNetCore.Mvc;
using DependencyInjectionApi.Services;

namespace DependencyInjectionApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();

            return Ok(employees);
        }
    }
}