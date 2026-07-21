// Program 22: Tuples and Deconstruction
// Demonstrates tuple syntax and destructuring patterns

using System;
using System.Collections.Generic;

class Program22_TuplesDeconstruction
{
    static void Main()
    {
        Console.WriteLine("=== TUPLES AND DECONSTRUCTION ===\n");

        // Creating tuples
        Console.WriteLine("--- CREATING TUPLES ---");
        var person = ("Alice", 30, "Engineer");
        Console.WriteLine($"Tuple: {person}");
        Console.WriteLine($"Access: {person.Item1}, {person.Item2}, {person.Item3}");

        // Named tuple elements
        (string Name, int Age, string Job) employee = ("Bob", 25, "Designer");
        Console.WriteLine($"\nNamed tuple: {employee.Name}, {employee.Age}, {employee.Job}");

        // Tuple deconstruction
        Console.WriteLine("\n--- DECONSTRUCTION ---");
        (string name, int age, string job) = employee;
        Console.WriteLine($"Deconstructed: {name} is {age} years old, works as {job}");

        // Partial deconstruction (using discard)
        (string empName, _, string empJob) = employee;
        Console.WriteLine($"Partial deconstruction: {empName} works as {empJob}");

        // Return multiple values from method
        Console.WriteLine("\n--- RETURNING MULTIPLE VALUES ---");
        var (success, message, data) = GetUserData(1);
        Console.WriteLine($"Success: {success}, Message: {message}, Data: {data}");

        var (success2, message2, _) = GetUserData(999);
        Console.WriteLine($"Success: {success2}, Message: {message2}");

        // Tuple as dictionary key
        Console.WriteLine("\n--- TUPLE AS DICTIONARY KEY ---");
        var coordinates = new Dictionary<(int, int), string>
        {
            { (0, 0), "Origin" },
            { (1, 1), "First Quadrant" },
            { (-1, 1), "Second Quadrant" }
        };

        if (coordinates.TryGetValue((0, 0), out var location))
        {
            Console.WriteLine($"Location at (0, 0): {location}");
        }

        // Comparing tuples
        Console.WriteLine("\n--- COMPARING TUPLES ---");
        var tuple1 = (1, "Alice");
        var tuple2 = (1, "Alice");
        var tuple3 = (1, "Bob");

        Console.WriteLine($"tuple1 == tuple2: {tuple1 == tuple2}");
        Console.WriteLine($"tuple1 == tuple3: {tuple1 == tuple3}");

        // Tuple in collections
        Console.WriteLine("\n--- TUPLES IN COLLECTIONS ---");
        var pairs = new List<(int Id, string Name)>
        {
            (1, "Alice"),
            (2, "Bob"),
            (3, "Charlie")
        };

        foreach (var (id, name) in pairs)
        {
            Console.WriteLine($"  ID: {id}, Name: {name}");
        }

        // Nested tuples
        Console.WriteLine("\n--- NESTED TUPLES ---");
        var nested = ("Alice", (30, "Engineer"));
        Console.WriteLine($"Person: {nested.Item1}");
        Console.WriteLine($"Age: {nested.Item2.Item1}, Job: {nested.Item2.Item2}");

        // Deconstruct nested tuple
        var (personName, (personAge, personJob)) = nested;
        Console.WriteLine($"Deconstructed nested: {personName}, {personAge}, {personJob}");

        // Tuple with many elements
        Console.WriteLine("\n--- LARGE TUPLE ---");
        var largeTuple = (Id: 1, Name: "Test", Email: "test@example.com", 
                         Active: true, Score: 95.5, Created: DateTime.Now);
        Console.WriteLine($"ID: {largeTuple.Id}, Name: {largeTuple.Name}, Active: {largeTuple.Active}");

        Console.WriteLine("\n=== BENEFITS OF TUPLES ===");
        Console.WriteLine("1. Return multiple values from methods");
        Console.WriteLine("2. Lightweight alternative to custom classes");
        Console.WriteLine("3. Cleaner deconstruction with named elements");
        Console.WriteLine("4. Use as dictionary keys");
        Console.WriteLine("5. Value-based equality comparison");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static (bool Success, string Message, string Data) GetUserData(int userId)
    {
        if (userId == 1)
        {
            return (true, "User found", "User data here");
        }
        else
        {
            return (false, "User not found", "");
        }
    }
}
