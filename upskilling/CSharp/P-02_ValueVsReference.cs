// Program 02: Explore Value Types vs Reference Types
// Demonstrates the difference between value types (int, struct) and reference types (class, string)

using System;

class Program02_ValueVsReference
{
    // Value Type: Struct
    struct Point
    {
        public int X, Y;
        public Point(int x, int y) { X = x; Y = y; }
        public override string ToString() => $"({X}, {Y})";
    }

    // Reference Type: Class
    class Person
    {
        public string Name { get; set; }
        public Person(string name) { Name = name; }
        public override string ToString() => Name;
    }

    static void Main()
    {
        // VALUE TYPE BEHAVIOR
        Point p1 = new Point(5, 10);
        Point p2 = p1; // Copy of the value
        p2.X = 20;     // Modifying p2 does NOT affect p1
        
        Console.WriteLine("=== VALUE TYPE (Struct) ===");
        Console.WriteLine($"p1: {p1} (Original)");
        Console.WriteLine($"p2: {p2} (Copy - X modified)");
        Console.WriteLine($"p1 is unchanged: {p1.X == 5}");

        // REFERENCE TYPE BEHAVIOR
        Person person1 = new Person("Alice");
        Person person2 = person1; // Reference to the same object
        person2.Name = "Bob";      // Modifying person2 DOES affect person1
        
        Console.WriteLine("\n=== REFERENCE TYPE (Class) ===");
        Console.WriteLine($"person1: {person1} (Original)");
        Console.WriteLine($"person2: {person2} (Same reference)");
        Console.WriteLine($"person1.Name changed to: {person1.Name}");

        // Memory comparison
        Console.WriteLine("\n=== MEMORY ALLOCATION ===");
        Console.WriteLine("Value Types: Allocated on STACK");
        Console.WriteLine("Reference Types: Allocated on HEAP (reference on stack)");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}