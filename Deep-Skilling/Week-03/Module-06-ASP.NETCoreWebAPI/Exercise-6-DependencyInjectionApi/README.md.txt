# Exercise 6 - Dependency Injection

## Objective

Demonstrate Dependency Injection in ASP.NET Core Web API by creating a service and injecting it into a controller.

## Technologies Used

- ASP.NET Core 8.0 Web API
- C#
- Swagger UI
- Visual Studio 2022

## Project Structure

- Models
- Services
- Controllers

## Tasks Performed

- Created Employee model
- Created IEmployeeService interface
- Implemented EmployeeService
- Registered the service using Dependency Injection
- Injected the service into EmployeeController
- Retrieved employee data using the service
- Tested the API using Swagger

## API Endpoint

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Employee | Returns the employee list |

## Output

Successfully implemented Dependency Injection and verified the API using Swagger.