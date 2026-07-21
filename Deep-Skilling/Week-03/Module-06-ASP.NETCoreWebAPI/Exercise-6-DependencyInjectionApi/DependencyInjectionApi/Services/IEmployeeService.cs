using DependencyInjectionApi.Models;

namespace DependencyInjectionApi.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}