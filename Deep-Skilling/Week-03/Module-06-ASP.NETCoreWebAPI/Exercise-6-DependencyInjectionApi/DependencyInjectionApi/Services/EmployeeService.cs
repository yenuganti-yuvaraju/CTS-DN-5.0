using DependencyInjectionApi.Models;

namespace DependencyInjectionApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
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
                    Salary = 45000
                }
            };
        }
    }
}