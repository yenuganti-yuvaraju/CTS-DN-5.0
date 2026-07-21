// Program 14: Inheritance and Method Overriding
// Demonstrates class hierarchy and polymorphic behavior

using System;
using System.Collections.Generic;

// Base class
abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method (can be overridden)
    public virtual void Eat()
    {
        Console.WriteLine($"{Name} is eating.");
    }

    // Abstract method (must be overridden)
    public abstract void MakeSound();

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

// Derived class
class Dog : Animal
{
    public string Breed { get; set; }

    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    // Override virtual method
    public override void Eat()
    {
        Console.WriteLine($"{Name} (Dog) is eating dog food.");
    }

    // Implement abstract method
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof! Woof!");
    }

    // Override ShowInfo
    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Breed: {Breed}");
    }

    // Dog-specific method
    public void Fetch()
    {
        Console.WriteLine($"{Name} is fetching the ball!");
    }
}

class Cat : Animal
{
    public string Color { get; set; }

    public Cat(string name, int age, string color) : base(name, age)
    {
        Color = color;
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} (Cat) is eating cat food.");
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Color: {Color}");
    }
}

class Program14_InheritanceMethodOverriding
{
    static void Main()
    {
        Console.WriteLine("=== INHERITANCE AND METHOD OVERRIDING ===\n");

        // Create instances
        Dog dog = new Dog("Buddy", 5, "Golden Retriever");
        Cat cat = new Cat("Whiskers", 3, "Orange");

        Console.WriteLine("--- DOG ---");
        dog.ShowInfo();
        dog.MakeSound();
        dog.Eat();
        dog.Fetch();

        Console.WriteLine("\n--- CAT ---");
        cat.ShowInfo();
        cat.MakeSound();
        cat.Eat();

        Console.WriteLine("\n--- POLYMORPHISM ---");
        Animal[] animals = { dog, cat };

        foreach (Animal animal in animals)
        {
            Console.WriteLine($"\n{animal.Name}:");
            animal.MakeSound();
            animal.Eat();
        }

        Console.WriteLine("\n--- POLYMORPHIC BEHAVIOR ---");
        List<Animal> animalList = new List<Animal>
        {
            new Dog("Max", 4, "Labrador"),
            new Cat("Luna", 2, "White"),
            new Dog("Charlie", 6, "Beagle")
        };

        foreach (Animal animal in animalList)
        {
            animal.ShowInfo();
            animal.MakeSound();
            Console.WriteLine();
        }

        Console.WriteLine("=== INHERITANCE CONCEPTS ===");
        Console.WriteLine("Base class: Provides common functionality");
        Console.WriteLine("Derived class: Inherits from base class");
        Console.WriteLine("Virtual method: Can be overridden");
        Console.WriteLine("Abstract method: Must be overridden");
        Console.WriteLine("Polymorphism: Same interface, different behavior");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}