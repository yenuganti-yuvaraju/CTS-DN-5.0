// Program 13: Records and `init` Properties
// Demonstrates immutable data structures with records

using System;

// Immutable record with init-only properties
record Address
{
    public string Street { get; init; }
    public string City { get; init; }
    public string ZipCode { get; init; }
}

// Record with primary constructor (C# 12)
record Person(string Name, int Age, string Email);

// Record with additional properties and methods
record Employee
{
    public required string Name { get; init; }
    public required string Department { get; init; }
    public decimal Salary { get; init; }
    public Address? WorkAddress { get; init; }

    // Method in record
    public void PrintDetails()
    {
        Console.WriteLine($"Name: {Name}, Dept: {Department}, Salary: ${Salary}");
        if (WorkAddress != null)
            Console.WriteLine($"Address: {WorkAddress.Street}, {WorkAddress.City}");
    }
}

class Program13_RecordsInitProperties
{
    static void Main()
    {
        Console.WriteLine("=== RECORDS WITH INIT PROPERTIES ===\n");

        // Create immutable record
        Address address = new Address
        {
            Street = "123 Main St",
            City = "Springfield",
            ZipCode = "12345"
        };

        Console.WriteLine("Address Record:");
        Console.WriteLine($"  {address.Street}, {address.City} {address.ZipCode}");

        Console.WriteLine("\n=== RECORD EQUALITY ===");
        Address address2 = new Address
        {
            Street = "123 Main St",
            City = "Springfield",
            ZipCode = "12345"
        };

        Console.WriteLine($"address == address2: {address == address2}");
        Console.WriteLine($"address.Equals(address2): {address.Equals(address2)}");
        Console.WriteLine($"ReferenceEquals(address, address2): {ReferenceEquals(address, address2)}");

        Console.WriteLine("\n=== WITH EXPRESSION (Copy + Modify) ===");
        Address newAddress = address with { City = "Shelbyville" };
        Console.WriteLine($"Original: {address.City}");
        Console.WriteLine($"Modified: {newAddress.City}");

        Console.WriteLine("\n=== PRIMARY CONSTRUCTOR ===");
        Person person = new Person("Bob", 30, "bob@example.com");
        Console.WriteLine($"Person: {person.Name}, Age: {person.Age}, Email: {person.Email}");

        Person person2 = person with { Age = 31 };
        Console.WriteLine($"Updated: {person2.Name}, Age: {person2.Age}");

        Console.WriteLine("\n=== RECORDS WITH REQUIRED PROPERTIES ===");
        Employee emp = new Employee
        {
            Name = "Alice",
            Department = "Engineering",
            Salary = 85000,
            WorkAddress = address
        };

        emp.PrintDetails();

        Console.WriteLine("\n=== RECORD DECONSTRUCTION ===");
        var (name, age, email) = person;
        Console.WriteLine($"Deconstructed: {name}, {age}, {email}");

        Console.WriteLine("\n=== BENEFITS OF RECORDS ===");
        Console.WriteLine("1. Value-based equality");
        Console.WriteLine("2. Immutability with init properties");
        Console.WriteLine("3. With expressions for modifications");
        Console.WriteLine("4. Built-in ToString override");
        Console.WriteLine("5. Deconstruction support");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}