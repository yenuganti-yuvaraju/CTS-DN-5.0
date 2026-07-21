// Program 15: Abstract Classes and Interfaces
// Demonstrates abstraction and contract-based programming

using System;
using System.Collections.Generic;

// Abstract class: Can have implementation and abstract members
abstract class Shape
{
    public string Name { get; set; }

    public Shape(string name)
    {
        Name = name;
    }

    // Abstract method (must be implemented)
    public abstract double GetArea();

    // Abstract method
    public abstract double GetPerimeter();

    // Concrete method (with implementation)
    public void Display()
    {
        Console.WriteLine($"Shape: {Name}");
        Console.WriteLine($"Area: {GetArea():F2}");
        Console.WriteLine($"Perimeter: {GetPerimeter():F2}");
    }
}

// Interface: Contract for all members
interface IColorable
{
    string Color { get; set; }
    void ChangeColor(string newColor);
}

interface IRotatable
{
    void Rotate(double degrees);
}

// Concrete class implementing abstract class and interfaces
class Circle : Shape, IColorable
{
    public double Radius { get; set; }
    public string Color { get; set; }

    public Circle(string name, double radius, string color) : base(name)
    {
        Radius = radius;
        Color = color;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void ChangeColor(string newColor)
    {
        Color = newColor;
        Console.WriteLine($"Color changed to {Color}");
    }
}

class Rectangle : Shape, IColorable, IRotatable
{
    public double Width { get; set; }
    public double Height { get; set; }
    public string Color { get; set; }
    public double Rotation { get; set; }

    public Rectangle(string name, double width, double height, string color) : base(name)
    {
        Width = width;
        Height = height;
        Color = color;
        Rotation = 0;
    }

    public override double GetArea()
    {
        return Width * Height;
    }

    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }

    public void ChangeColor(string newColor)
    {
        Color = newColor;
        Console.WriteLine($"Color changed to {Color}");
    }

    public void Rotate(double degrees)
    {
        Rotation = (Rotation + degrees) % 360;
        Console.WriteLine($"Rotated by {degrees}°. Current rotation: {Rotation}°");
    }
}

class Program15_AbstractClassesInterfaces
{
    static void Main()
    {
        Console.WriteLine("=== ABSTRACT CLASSES AND INTERFACES ===\n");

        // Create instances (cannot instantiate abstract class)
        Circle circle = new Circle("Red Circle", 5, "Red");
        Rectangle rectangle = new Rectangle("Blue Rectangle", 4, 6, "Blue");

        Console.WriteLine("--- CIRCLE ---");
        circle.Display();

        Console.WriteLine("\n--- RECTANGLE ---");
        rectangle.Display();

        Console.WriteLine("\n--- INTERFACE: IColorable ---");
        circle.ChangeColor("Green");
        rectangle.ChangeColor("Yellow");

        Console.WriteLine("\n--- INTERFACE: IRotatable ---");
        rectangle.Rotate(45);
        rectangle.Rotate(45);

        Console.WriteLine("\n--- POLYMORPHIC SHAPES ---");
        Shape[] shapes = { circle, rectangle };

        foreach (Shape shape in shapes)
        {
            shape.Display();
            Console.WriteLine();
        }

        Console.WriteLine("--- POLYMORPHIC INTERFACE USAGE ---");
        List<IColorable> colorables = new List<IColorable> { circle, rectangle };

        foreach (IColorable colorable in colorables)
        {
            colorable.ChangeColor("Purple");
        }

        Console.WriteLine("\n=== ABSTRACT vs INTERFACE ===");
        Console.WriteLine("Abstract Class:");
        Console.WriteLine("  - Can have state (fields)");
        Console.WriteLine("  - Can have implementation");
        Console.WriteLine("  - Can have access modifiers");
        Console.WriteLine("  - Single inheritance");
        Console.WriteLine("\nInterface:");
        Console.WriteLine("  - No state (only properties/methods)");
        Console.WriteLine("  - Only contracts (no implementation, until C# 8)");
        Console.WriteLine("  - All members public");
        Console.WriteLine("  - Multiple implementation");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}