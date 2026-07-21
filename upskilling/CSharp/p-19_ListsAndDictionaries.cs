// Program 19: Lists and Dictionaries
// Demonstrates collection types for storing and managing data

using System;
using System.Collections.Generic;
using System.Linq;

class Program19_ListsAndDictionaries
{
    static void Main()
    {
        Console.WriteLine("=== LISTS AND DICTIONARIES ===\n");

        // Working with Lists
        Console.WriteLine("--- LISTS ---");
        WorkingWithLists();

        // Working with Dictionaries
        Console.WriteLine("\n--- DICTIONARIES ---");
        WorkingWithDictionaries();

        // Advanced operations
        Console.WriteLine("\n--- ADVANCED OPERATIONS ---");
        AdvancedOperations();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void WorkingWithLists()
    {
        List<string> fruits = new List<string> { "Apple", "Banana", "Orange" };

        Console.WriteLine("Initial List:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"  - {fruit}");
        }

        // Add items
        fruits.Add("Mango");
        fruits.AddRange(new[] { "Grapes", "Kiwi" });

        Console.WriteLine("\nAfter adding items:");
        Console.WriteLine($"  Count: {fruits.Count}");
        Console.WriteLine($"  Items: {string.Join(", ", fruits)}");

        // Insert and remove
        fruits.Insert(1, "Pineapple");
        fruits.Remove("Banana");

        Console.WriteLine("\nAfter insert and remove:");
        Console.WriteLine($"  Items: {string.Join(", ", fruits)}");

        // Find operations
        if (fruits.Contains("Mango"))
            Console.WriteLine("  Contains 'Mango': Yes");

        int index = fruits.IndexOf("Orange");
        Console.WriteLine($"  Index of 'Orange': {index}");

        // List of custom objects
        Console.WriteLine("\n--- LIST OF OBJECTS ---");
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 30 },
            new Person { Name = "Bob", Age = 25 },
            new Person { Name = "Charlie", Age = 35 }
        };

        foreach (Person p in people)
        {
            Console.WriteLine($"  {p.Name}: {p.Age} years old");
        }
    }

    static void WorkingWithDictionaries()
    {
        Dictionary<string, int> scores = new Dictionary<string, int>
        {
            { "Alice", 95 },
            { "Bob", 87 },
            { "Charlie", 92 }
        };

        Console.WriteLine("Initial Dictionary:");
        foreach (var kvp in scores)
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
        }

        // Add items
        scores.Add("Diana", 89);
        scores["Eve"] = 91;

        Console.WriteLine($"\nAfter adding items: {scores.Count} entries");

        // Access values
        int aliceScore = scores["Alice"];
        Console.WriteLine($"Alice's score: {aliceScore}");

        // TryGetValue (safe access)
        if (scores.TryGetValue("Frank", out int frankScore))
        {
            Console.WriteLine($"Frank's score: {frankScore}");
        }
        else
        {
            Console.WriteLine("Frank not found in dictionary");
        }

        // Dictionary operations
        Console.WriteLine($"\nKeys: {string.Join(", ", scores.Keys)}");
        Console.WriteLine($"Values: {string.Join(", ", scores.Values)}");

        // Dictionary of custom objects
        Console.WriteLine("\n--- DICTIONARY OF OBJECTS ---");
        Dictionary<string, Person> employees = new Dictionary<string, Person>
        {
            { "EMP001", new Person { Name = "Alice", Age = 30 } },
            { "EMP002", new Person { Name = "Bob", Age = 25 } }
        };

        if (employees.TryGetValue("EMP001", out Person emp))
        {
            Console.WriteLine($"  {emp.Name} ({emp.Age} years)");
        }
    }

    static void AdvancedOperations()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // LINQ operations
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");

        var squared = numbers.Select(n => n * n);
        Console.WriteLine($"Squared: {string.Join(", ", squared)}");

        var sum = numbers.Sum();
        var average = numbers.Average();
        Console.WriteLine($"Sum: {sum}, Average: {average:F2}");

        // Dictionary operations
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            { "Apples", 10 },
            { "Bananas", 5 },
            { "Oranges", 8 }
        };

        Console.WriteLine("\n--- FILTERED DICTIONARY ---");
        var lowStock = inventory.Where(item => item.Value < 8);
        foreach (var item in lowStock)
        {
            Console.WriteLine($"  {item.Key}: {item.Value} (low stock)");
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}