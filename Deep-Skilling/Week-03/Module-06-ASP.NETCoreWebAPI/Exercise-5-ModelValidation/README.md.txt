# Exercise 5 - Model Validation

## Objective
The objective of this exercise is to implement model validation in an ASP.NET Core Web API using Data Annotations. Validation ensures that only valid data is accepted before processing API requests.

## Technologies Used
- ASP.NET Core 8.0 Web API
- C#
- Swagger UI
- Visual Studio 2022

## Model Validation Attributes Used
- `[Required]`
- `[StringLength]`
- `[Range]`

## Employee Model

The Employee model contains the following properties:

| Property | Validation |
|----------|------------|
| Id | Integer |
| Name | Required |
| Salary | Range (10000 - 100000) |
| Department | Required |

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/Employee | Retrieves all employees |
| POST | /api/Employee | Adds a new employee with validation |

## Validation Scenarios Tested

### Test 1 - Valid Employee Data
- Request with valid employee details
- Result: **200 OK**

### Test 2 - Empty Employee Name
- Name field left empty
- Result: **400 Bad Request**

### Test 3 - Invalid Salary
- Salary below minimum allowed value
- Result: **400 Bad Request**

### Test 4 - Empty Department
- Department field left empty
- Result: **400 Bad Request**

## Output Screenshots

The following screenshots are included in the Output folder:

- 01-Valid-Employee-Data.png
- 02-Name-Validation-Error.png
- 03-Salary-Validation-Error.png
- 04-Department-Validation-Error.png

## Outcome

Successfully implemented model validation using Data Annotations in ASP.NET Core Web API. The API correctly validates user input and returns appropriate HTTP status codes and validation error messages.