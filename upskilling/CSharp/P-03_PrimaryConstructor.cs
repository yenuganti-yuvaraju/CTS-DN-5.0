// Program 03: Primary Constructors in C# 12
// Demonstrates the new primary constructor syntax for cleaner class initialization

using System;

// Primary Constructor: Parameters become class fields directly
class Student(string name, int age, double gpa)
{
    public string Name => name;           // Read-only property
    public int Age => age;
    public double GPA => gpa;

    public override string ToString() => $"Name: {Name}, Age: {Age}, GPA: {GPA:F2}";

    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"GPA: {GPA:F2}");
    }
}

// Record with Primary Constructor (also supports this syntax)
record Teacher(string Name, string Subject, int Experience);

class Program03_PrimaryConstructor
{
    static void Main()
    {
        // Create student using primary constructor
        Student student = new Student("John Doe", 20, 3.85);
        Console.WriteLine("=== PRIMARY CONSTRUCTOR ===");
        Console.WriteLine(student);
        student.DisplayInfo();

        // Create teacher using record with primary constructor
        Teacher teacher = new Teacher("Ms. Smith", "Mathematics", 10);
        Console.WriteLine("\n=== RECORD WITH PRIMARY CONSTRUCTOR ===");
        Console.WriteLine($"Teacher: {teacher.Name}");
        Console.WriteLine($"Subject: {teacher.Subject}");
        Console.WriteLine($"Experience: {teacher.Experience} years");

        // Record deconstruction
        var (name, subject, exp) = teacher;
        Console.WriteLine($"\nDeconstructed: {name} teaches {subject}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}