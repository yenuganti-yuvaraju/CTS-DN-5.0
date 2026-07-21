// Program 17: Null Conditional Chaining
// Demonstrates safe navigation through potentially null references

using System;

#nullable enable

class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string? ZipCode { get; set; }
}

class Employee
{
    public string Name { get; set; }
    public Address? WorkAddress { get; set; }
    public int? ManagerId { get; set; }

    public Employee(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}

class Program17_NullConditionalChaining
{
    static void Main()
    {
        Console.WriteLine("=== NULL CONDITIONAL CHAINING ===\n");

        // Employee with address
        Employee emp1 = new Employee("Alice");
        emp1.WorkAddress = new Address 
        { 
            Street = "123 Main St", 
            City = "Springfield",
            ZipCode = "12345"
        };

        // Employee without address
        Employee emp2 = new Employee("Bob");
        emp2.WorkAddress = null;

        Console.WriteLine("--- NULL CONDITIONAL OPERATOR (?.) ---");
        Console.WriteLine($"emp1.WorkAddress?.Street: {emp1.WorkAddress?.Street}");
        Console.WriteLine($"emp2.WorkAddress?.Street: {emp2.WorkAddress?.Street}");

        Console.WriteLine("\n--- NULL COALESCING WITH CHAINING ---");
        string city1 = emp1.WorkAddress?.City ?? "Unknown City";
        string city2 = emp2.WorkAddress?.City ?? "Unknown City";
        Console.WriteLine($"emp1 city: {city1}");
        Console.WriteLine($"emp2 city: {city2}");

        Console.WriteLine("\n--- CHAINING MULTIPLE LEVELS ---");
        string zipCode1 = emp1.WorkAddress?.ZipCode ?? "No zip";
        string zipCode2 = emp2.WorkAddress?.ZipCode ?? "No zip";
        Console.WriteLine($"emp1 zip: {zipCode1}");
        Console.WriteLine($"emp2 zip: {zipCode2}");

        Console.WriteLine("\n--- NULL CONDITIONAL WITH COLLECTIONS ---");
        int? length1 = emp1.WorkAddress?.Street?.Length;
        int? length2 = emp2.WorkAddress?.Street?.Length;
        Console.WriteLine($"emp1 street length: {length1}");
        Console.WriteLine($"emp2 street length: {length2}");

        Console.WriteLine("\n--- NULL CONDITIONAL WITH METHOD CALLS ---");
        string info1 = GetAddressInfo(emp1);
        string info2 = GetAddressInfo(emp2);
        Console.WriteLine($"emp1: {info1}");
        Console.WriteLine($"emp2: {info2}");

        Console.WriteLine("\n--- NULL COALESCING ASSIGNMENT (C# 8.0+) ---");
        emp2.WorkAddress ??= new Address { Street = "Default St", City = "Default City" };
        Console.WriteLine($"emp2 after assignment: {emp2.WorkAddress?.City}");

        Console.WriteLine("\n=== WITHOUT NULL CONDITIONAL (DANGEROUS) ===");
        try
        {
            // This would throw NullReferenceException
            // Console.WriteLine(emp2.WorkAddress.Street);
            Console.WriteLine("(Skipped - would cause NullReferenceException)");
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\n=== BENEFITS OF NULL CONDITIONAL CHAINING ===");
        Console.WriteLine("1. Safe navigation through null references");
        Console.WriteLine("2. No NullReferenceException");
        Console.WriteLine("3. Cleaner code than null checks");
        Console.WriteLine("4. Works with properties, methods, and indexers");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static string GetAddressInfo(Employee emp)
    {
        return emp.WorkAddress switch
        {
            null => "No address",
            { Street: not null, City: not null } => 
                $"{emp.WorkAddress.Street}, {emp.WorkAddress.City}",
            _ => "Incomplete address"
        };
    }
}