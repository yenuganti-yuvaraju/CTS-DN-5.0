// Program 10: Constructors (Default and Parameterized)
// Demonstrates constructor initialization patterns

using System;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double GPA { get; set; }

    // Default constructor (parameterless)
    public Student()
    {
        Name = "Unknown";
        Age = 0;
        GPA = 0.0;
        Console.WriteLine("Default Constructor called");
    }

    // Parameterized constructor
    public Student(string name, int age, double gpa)
    {
        Name = name;
        Age = age;
        GPA = gpa;
        Console.WriteLine($"Parameterized Constructor called for {name}");
    }

    // Constructor with fewer parameters (overloaded)
    public Student(string name)
    {
        Name = name;
        Age = 18;
        GPA = 3.0;
        Console.WriteLine($"Single-parameter Constructor called for {name}");
    }

    // Constructor chaining using 'this'
    public Student(string name, int age) : this(name, age, 3.5)
    {
        Console.WriteLine($"Two-parameter Constructor called (chains to 3-param)");
    }

    public override string ToString()
    {
        return $"Student: {Name}, Age: {Age}, GPA: {GPA:F2}";
    }

    // Destructor (rarely used in modern C#)
    ~Student()
    {
        Console.WriteLine($"Destructor called for {Name}");
    }
}

// Record with constructor (C# 9+)
record Employee(string Name, string Department, decimal Salary);

class Program10_Constructors
{
    static void Main()
    {
        Console.WriteLine("=== DEFAULT CONSTRUCTOR ===");
        Student s1 = new Student();
        Console.WriteLine(s1);

        Console.WriteLine("\n=== PARAMETERIZED CONSTRUCTOR ===");
        Student s2 = new Student("Alice", 20, 3.85);
        Console.WriteLine(s2);

        Console.WriteLine("\n=== SINGLE-PARAMETER CONSTRUCTOR ===");
        Student s3 = new Student("Bob");
        Console.WriteLine(s3);

        Console.WriteLine("\n=== CONSTRUCTOR CHAINING ===");
        Student s4 = new Student("Charlie", 21);
        Console.WriteLine(s4);

        Console.WriteLine("\n=== RECORD CONSTRUCTOR ===");
        Employee emp = new Employee("Diana", "Engineering", 75000);
        Console.WriteLine($"Employee: {emp.Name}, Dept: {emp.Department}, Salary: ${emp.Salary}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}