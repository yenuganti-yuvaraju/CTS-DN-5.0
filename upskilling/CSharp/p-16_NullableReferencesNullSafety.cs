// Program 16: Nullable References and Null Safety
// Demonstrates null-safety features in C# 8+

using System;

#nullable enable // Enable nullable reference types

class Person
{
    // Non-nullable reference type
    public string Name { get; set; } = string.Empty;

    // Nullable reference type
    public string? MiddleName { get; set; }

    // Non-nullable value type (cannot be null)
    public int Age { get; set; }

    // Nullable value type
    public int? PhoneNumber { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Middle Name: {MiddleName ?? "Not provided"}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Phone: {PhoneNumber?.ToString() ?? "Not provided"}");
    }
}

class Program16_NullableReferencesNullSafety
{
    static void Main()
    {
        Console.WriteLine("=== NULLABLE REFERENCES AND NULL SAFETY ===\n");

        // Creating person
        Person person = new Person("Alice", 30);
        person.MiddleName = "Marie";
        person.PhoneNumber = 5551234567;

        Console.WriteLine("--- PERSON WITH DATA ---");
        person.DisplayInfo();

        // Person without optional data
        Person person2 = new Person("Bob", 25);
        // person2.MiddleName = null; // Allowed (nullable string)
        // person2.PhoneNumber = null; // Allowed (nullable int)

        Console.WriteLine("\n--- PERSON WITHOUT OPTIONAL DATA ---");
        person2.DisplayInfo();

        Console.WriteLine("\n=== NULL COALESCING ===");
        string? nullValue = null;
        string result = nullValue ?? "Default Value";
        Console.WriteLine($"Result: {result}");

        Console.WriteLine("\n=== NULL CONDITIONAL OPERATOR ===");
        string? text = "Hello";
        Console.WriteLine($"text?.Length = {text?.Length}");

        text = null;
        Console.WriteLine($"text?.Length = {text?.Length}"); // Returns null (no exception)

        Console.WriteLine("\n=== NULLABLE VALUE TYPES ===");
        int? nullableInt = null;
        int? anotherInt = 42;

        if (nullableInt.HasValue)
            Console.WriteLine($"nullableInt: {nullableInt.Value}");
        else
            Console.WriteLine("nullableInt: is null");

        if (anotherInt.HasValue)
            Console.WriteLine($"anotherInt: {anotherInt.Value}");

        Console.WriteLine($"anotherInt.GetValueOrDefault(): {anotherInt.GetValueOrDefault()}");
        Console.WriteLine($"nullableInt.GetValueOrDefault(): {nullableInt.GetValueOrDefault()}");

        Console.WriteLine("\n=== PATTERN MATCHING WITH NULL ===");
        TestNullPattern(null);
        TestNullPattern("Hello");
        TestNullPattern("");

        Console.WriteLine("\n=== BENEFITS ===");
        Console.WriteLine("1. Eliminates NullReferenceException at compile-time");
        Console.WriteLine("2. Explicit null-safety declarations");
        Console.WriteLine("3. Better code readability");
        Console.WriteLine("4. Compiler warnings for potential null issues");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void TestNullPattern(string? value)
    {
        string result = value switch
        {
            null => "Value is null",
            "" => "Value is empty string",
            _ => $"Value: {value}"
        };
        Console.WriteLine(result);
    }
}