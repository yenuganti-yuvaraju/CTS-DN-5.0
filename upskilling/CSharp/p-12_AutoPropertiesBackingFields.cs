// Program 12: Auto Properties and Backing Fields
// Demonstrates property patterns for encapsulation

using System;

class Person
{
    // Auto-property (backing field is generated automatically)
    public string Name { get; set; }

    // Auto-property with private setter
    public int Age { get; private set; }

    // Auto-property with initialization
    public string Email { get; set; } = "noemail@example.com";

    // Backing field with property
    private double salary;
    public double Salary
    {
        get { return salary; }
        set { salary = value > 0 ? value : 0; } // Validation in setter
    }

    // Expression-bodied property
    public bool IsAdult => Age >= 18;

    // Read-only property (init-only in C# 9+)
    public string EmployeeId { get; init; }

    // Nullable backing field
    private string? phone;
    public string? Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    // Constructor
    public Person(string name, int age, string employeeId)
    {
        Name = name;
        Age = age;
        EmployeeId = employeeId;
    }

    // Method to modify age
    public void HaveBirthday()
    {
        Age++;
        Console.WriteLine($"Happy Birthday, {Name}! You are now {Age}.");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Email: {Email}, Salary: ${Salary:F2}, Adult: {IsAdult}";
    }
}

// Record with init-only properties (C# 9+)
record Product
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
}

class Program12_AutoPropertiesBackingFields
{
    static void Main()
    {
        Console.WriteLine("=== AUTO-PROPERTIES ===\n");

        Person person = new Person("Alice", 25, "EMP001");
        person.Salary = 50000;
        person.Phone = "555-1234";

        Console.WriteLine(person);
        Console.WriteLine($"Email: {person.Email}");
        Console.WriteLine($"Phone: {person.Phone}");

        Console.WriteLine("\n=== PROPERTY VALIDATION ===");
        person.Salary = -1000; // Invalid salary
        Console.WriteLine($"Salary (after invalid input): ${person.Salary}");

        person.Salary = 65000; // Valid salary
        Console.WriteLine($"Salary (after valid input): ${person.Salary}");

        Console.WriteLine("\n=== AGE MODIFICATION ===");
        person.HaveBirthday();
        Console.WriteLine($"Is Adult: {person.IsAdult}");

        Console.WriteLine("\n=== INIT-ONLY PROPERTIES (Record) ===");
        Product product = new Product 
        { 
            Name = "Laptop", 
            Price = 999.99m, 
            Stock = 50 
        };
        Console.WriteLine($"Product: {product.Name}, Price: ${product.Price}, Stock: {product.Stock}");
        // product.Price = 899; // ERROR: init-only property cannot be modified

        Console.WriteLine("\n=== PATTERNS ===");
        Console.WriteLine("Auto-property:    Compact, generated backing field");
        Console.WriteLine("Backing field:    Full control, validation logic");
        Console.WriteLine("Expression-body:  Read-only, computed values");
        Console.WriteLine("Init-only:        Immutable after construction");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}