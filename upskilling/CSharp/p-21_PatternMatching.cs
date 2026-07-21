// Program 21: Pattern Matching with `is` and `switch`
// Demonstrates advanced pattern matching in C# 7+

using System;

class Program21_PatternMatching
{
    // Different object types for pattern matching
    abstract class Shape
    {
        public abstract double GetArea();
    }

    class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea() => Math.PI * Radius * Radius;
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double GetArea() => Width * Height;
    }

    class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public override double GetArea() => Base * Height / 2;
    }

    static void Main()
    {
        Console.WriteLine("=== PATTERN MATCHING ===\n");

        // Type pattern matching with 'is'
        Console.WriteLine("--- TYPE PATTERN WITH 'IS' ---");
        object[] objects = { 42, "Hello", 3.14, true, new Circle { Radius = 5 } };

        foreach (object obj in objects)
        {
            if (obj is Circle c)
            {
                Console.WriteLine($"Circle - Area: {c.GetArea():F2}");
            }
            else if (obj is string s)
            {
                Console.WriteLine($"String: {s}");
            }
            else if (obj is int i)
            {
                Console.WriteLine($"Integer: {i}");
            }
            else if (obj is double d)
            {
                Console.WriteLine($"Double: {d}");
            }
        }

        // Property pattern matching
        Console.WriteLine("\n--- PROPERTY PATTERN ---");
        Shape[] shapes = new Shape[]
        {
            new Circle { Radius = 5 },
            new Rectangle { Width = 4, Height = 6 },
            new Triangle { Base = 3, Height = 4 }
        };

        foreach (Shape shape in shapes)
        {
            string type = shape switch
            {
                Circle { Radius: > 5 } => "Large Circle",
                Circle { Radius: <= 5 } => "Small Circle",
                Rectangle { Width: > Height } => "Wide Rectangle",
                Rectangle { Width: <= Height } => "Tall Rectangle",
                Triangle => "Triangle",
                _ => "Unknown"
            };
            Console.WriteLine($"{shape.GetType().Name}: {type} - Area: {shape.GetArea():F2}");
        }

        // Relational pattern matching
        Console.WriteLine("\n--- RELATIONAL PATTERN ---");
        int[] numbers = { -5, 0, 5, 10, 25, 100 };

        foreach (int num in numbers)
        {
            string category = num switch
            {
                < 0 => "Negative",
                0 => "Zero",
                > 0 and < 10 => "Small positive",
                >= 10 and < 50 => "Medium positive",
                >= 50 => "Large positive",
                _ => "Unknown"
            };
            Console.WriteLine($"{num}: {category}");
        }

        // Logical pattern matching (and, or, not)
        Console.WriteLine("\n--- LOGICAL PATTERNS ---");
        (int, int)[] coordinates = { (1, 1), (5, 5), (-3, 2), (0, 0) };

        foreach (var (x, y) in coordinates)
        {
            string location = (x, y) switch
            {
                (0, 0) => "Origin",
                (> 0, > 0) => "First Quadrant",
                (< 0, > 0) => "Second Quadrant",
                (< 0, < 0) => "Third Quadrant",
                (> 0, < 0) => "Fourth Quadrant",
                _ => "On axis"
            };
            Console.WriteLine($"({x}, {y}): {location}");
        }

        // List pattern matching (C# 9+)
        Console.WriteLine("\n--- LIST PATTERN ---");
        int[][] arrays = new[]
        {
            new[] { 1, 2, 3 },
            new[] { 1 },
            new[] { 1, 2 },
            new int[] { }
        };

        foreach (int[] arr in arrays)
        {
            string description = arr switch
            {
                [] => "Empty array",
                [var x] => $"Single element: {x}",
                [1, 2, ..] => "Starts with 1, 2",
                [.., var last] => $"Last element: {last}",
                _ => "Other array"
            };
            Console.WriteLine($"[{string.Join(", ", arr)}]: {description}");
        }

        // Combining patterns
        Console.WriteLine("\n--- COMBINED PATTERNS ---");
        TestValue(null);
        TestValue("");
        TestValue("Hello");
        TestValue(42);
    }

    static void TestValue(object? value)
    {
        string result = value switch
        {
            null => "Is null",
            "" => "Empty string",
            string s and not null => $"String: {s}",
            int i and > 0 => $"Positive integer: {i}",
            int i and <= 0 => $"Non-positive integer: {i}",
            _ => "Other type"
        };
        Console.WriteLine(result);
    }
}
