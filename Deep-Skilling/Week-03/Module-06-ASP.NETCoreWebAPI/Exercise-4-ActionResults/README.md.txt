# Exercise 4 – Action Results & HTTP Status Codes

## Objective
Learn how to return proper HTTP status codes in ASP.NET Core Web API.

## Endpoints

### GET /api/student
Returns all students (200 OK).

### GET /api/student/{id}
Returns a student by ID.
- 200 OK (if found)
- 404 Not Found (if not found)

### POST /api/student
Adds a new student.
- 201 Created (valid request)
- 400 Bad Request (invalid request)

## Output
Successfully tested all APIs using Swagger UI.

## Status Codes Tested
- 200 OK
- 201 Created
- 400 Bad Request
- 404 Not Found