using System.ComponentModel.DataAnnotations;

namespace ModelValidationApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; } = "";

        [Range(10000, 100000, ErrorMessage = "Salary must be between 10000 and 100000")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; } = "";
    }
}