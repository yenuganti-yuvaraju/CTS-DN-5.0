// Program 04: Type Inference using `var` and `new()`
// Demonstrates C# type inference for cleaner and more readable code

using System;
using System.Collections.Generic;

class Program04_TypeInference
{
    static void Main()
    {
        Console.WriteLine("=== TYPE INFERENCE WITH 'var' ===");

        // Implicit typing with var
        var message = "Hello, C#!";              // Inferred as string
        var number = 42;                         // Inferred as int
        var price = 19.99;                       // Inferred as double
        var isActive = true;                     // Inferred as bool
        var dates = new List<DateTime>();       // Inferred as List<DateTime>

        Console.WriteLine($"message: {message} (Type: {message.GetType().Name})");
        Console.WriteLine($"number: {number} (Type: {number.GetType().Name})");
        Console.WriteLine($"price: {price} (Type: {price.GetType().Name})");
        Console.WriteLine($"isActive: {isActive} (Type: {isActive.GetType().Name})");
        Console.WriteLine($"dates: {dates.GetType().Name}");

        Console.WriteLine("\n=== TARGET-TYPED 'new' EXPRESSION ===");

        // Traditional: List<int> numbers = new List<int>();
        // Modern: Type inferred from variable declaration
        List<int> numbers = new();               // Inferred as List<int>
        Dictionary<string, int> scores = new(); // Inferred as Dictionary<string, int>

        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);

        scores["Alice"] = 95;
        scores["Bob"] = 87;

        Console.WriteLine("numbers: " + string.Join(", ", numbers));
        Console.WriteLine("scores: " + string.Join(", ", scores));

        Console.WriteLine("\n=== BENEFITS OF TYPE INFERENCE ===");
        Console.WriteLine("1. Cleaner, more readable code");
        Console.WriteLine("2. Reduced redundancy in type declarations");
        Console.WriteLine("3. Easier refactoring");
        Console.WriteLine("4. Still type-safe (checked at compile time)");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}