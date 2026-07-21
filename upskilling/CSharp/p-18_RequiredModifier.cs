// Program 18: Required Modifier in C# 12
// Demonstrates mandatory property initialization

using System;

#nullable enable

class Student
{
    // Required property: Must be initialized
    public required string Name { get; init; }

    // Required property
    public required int StudentId { get; init; }

    // Optional property
    public string? Email { get; set; }

    // Optional property with default
    public int GPA { get; set; } = 0;

    // Demonstrates that required works with init
    public required string Department { get; init; }
}

record PersonRecord
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public string? MiddleName { get; init; }
}

class Program18_RequiredModifier
{
    static void Main()
    {
        Console.WriteLine("=== REQUIRED MODIFIER (C# 12) ===\n");

        // Correct usage: All required properties initialized
        Student student1 = new Student
        {
            Name = "Alice",
            StudentId = 1001,
            Department = "Engineering",
            Email = "alice@example.com"
        };

        Console.WriteLine("--- STUDENT WITH ALL REQUIRED PROPERTIES ---");
        Console.WriteLine($"Name: {student1.Name}");
        Console.WriteLine($"ID: {student1.StudentId}");
        Console.WriteLine($"Department: {student1.Department}");
        Console.WriteLine($"Email: {student1.Email}");
        Console.WriteLine($"GPA: {student1.GPA}");

        // Missing required properties would cause compilation error
        // Student student2 = new Student { Name = "Bob" }; // ERROR: Missing StudentId, Department

        Console.WriteLine("\n--- PARTIAL INITIALIZATION (WITH OPTIONAL PROPERTIES) ---");
        Student student3 = new Student
        {
            Name = "Bob",
            StudentId = 1002,
            Department = "Business"
            // Email is optional, so it can be omitted
        };

        Console.WriteLine($"Name: {student3.Name}");
        Console.WriteLine($"ID: {student3.StudentId}");
        Console.WriteLine($"Department: {student3.Department}");
        Console.WriteLine($"Email: {student3.Email ?? "Not provided"}");

        Console.WriteLine("\n--- RECORD WITH REQUIRED PROPERTIES ---");
        PersonRecord person = new PersonRecord
        {
            FirstName = "Charlie",
            LastName = "Brown",
            MiddleName = "William"  // Optional
        };

        Console.WriteLine($"Name: {person.FirstName} {person.MiddleName ?? ""} {person.LastName}");

        Console.WriteLine("\n--- WITHOUT REQUIRED (WOULD COMPILE) ---");
        PersonRecord person2 = new PersonRecord
        {
            FirstName = "Diana",
            LastName = "Prince"
            // MiddleName is optional
        };

        Console.WriteLine($"Name: {person2.FirstName} {person2.LastName}");

        Console.WriteLine("\n=== BENEFITS OF REQUIRED MODIFIER ===");
        Console.WriteLine("1. Enforces initialization of important properties");
        Console.WriteLine("2. Prevents incomplete object construction");
        Console.WriteLine("3. Clear intent in code");
        Console.WriteLine("4. Compile-time validation");
        Console.WriteLine("5. Works with init properties for immutability");

        Console.WriteLine("\n=== USE CASES ===");
        Console.WriteLine("1. Domain entities requiring certain fields");
        Console.WriteLine("2. Configuration objects needing mandatory settings");
        Console.WriteLine("3. Data transfer objects (DTOs)");
        Console.WriteLine("4. API models requiring specific fields");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
