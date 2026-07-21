// Program 24: JSON Serialization and Deserialization
// Demonstrates working with JSON using System.Text.Json

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program24_JSONSerializationDeserialization
{
    [JsonSerializable]
    class Person
    {
        [JsonPropertyName("full_name")]
        public string Name { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string InternalId { get; set; }
    }

    class Company
    {
        public string CompanyName { get; set; }
        public List<Person> Employees { get; set; }
        public DateTime Founded { get; set; }
    }

    static void Main()
    {
        Console.WriteLine("=== JSON SERIALIZATION & DESERIALIZATION ===\n");

        // Serialize object to JSON
        Console.WriteLine("--- SERIALIZATION ---");
        var person = new Person
        {
            Name = "Alice",
            Age = 30,
            Email = "alice@example.com",
            InternalId = "EMP001"
        };

        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(person, options);
        Console.WriteLine("Person as JSON:");
        Console.WriteLine(jsonString);

        // Deserialize JSON to object
        Console.WriteLine("\n--- DESERIALIZATION ---");
        string jsonInput = """
        {
            "full_name": "Bob",
            "age": 25,
            "email": "bob@example.com"
        }
        """;

        var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonInput);
        Console.WriteLine($"Deserialized: {deserializedPerson.Name}, {deserializedPerson.Age}, {deserializedPerson.Email}");

        // Serialize complex object
        Console.WriteLine("\n--- COMPLEX OBJECT SERIALIZATION ---");
        var company = new Company
        {
            CompanyName = "Tech Corp",
            Founded = new DateTime(2020, 1, 15),
            Employees = new List<Person>
            {
                new Person { Name = "Alice", Age = 30, Email = "alice@techcorp.com" },
                new Person { Name = "Bob", Age = 28, Email = "bob@techcorp.com" },
                new Person { Name = "Charlie", Age = 35, Email = "charlie@techcorp.com" }
            }
        };

        string companyJson = JsonSerializer.Serialize(company, options);
        Console.WriteLine("Company as JSON:");
        Console.WriteLine(companyJson);

        // Deserialize complex object
        Console.WriteLine("\n--- COMPLEX OBJECT DESERIALIZATION ---");
        string companyJsonInput = """
        {
            "CompanyName": "StartUp Inc",
            "Founded": "2022-06-01T00:00:00",
            "Employees": [
                {"full_name": "Diana", "age": 26, "email": "diana@startup.com"},
                {"full_name": "Eve", "age": 29, "email": "eve@startup.com"}
            ]
        }
        """;

        var deserializedCompany = JsonSerializer.Deserialize<Company>(companyJsonInput);
        Console.WriteLine($"Company: {deserializedCompany.CompanyName} ({deserializedCompany.Employees.Count} employees)");
        foreach (var emp in deserializedCompany.Employees)
        {
            Console.WriteLine($"  - {emp.Name}: {emp.Email}");
        }

        // Working with arrays
        Console.WriteLine("\n--- ARRAY SERIALIZATION ---");
        int[] numbers = { 1, 2, 3, 4, 5 };
        string numbersJson = JsonSerializer.Serialize(numbers, options);
        Console.WriteLine("Array as JSON:");
        Console.WriteLine(numbersJson);

        int[] deserializedNumbers = JsonSerializer.Deserialize<int[]>(numbersJson);
        Console.WriteLine($"Deserialized array: {string.Join(", ", deserializedNumbers)}");

        // Working with dictionaries
        Console.WriteLine("\n--- DICTIONARY SERIALIZATION ---");
        var settings = new Dictionary<string, object>
        {
            { "theme", "dark" },
            { "notifications", true },
            { "timeout", 30 }
        };

        string settingsJson = JsonSerializer.Serialize(settings, options);
        Console.WriteLine("Dictionary as JSON:");
        Console.WriteLine(settingsJson);

        Console.WriteLine("\n=== SERIALIZATION OPTIONS ===");
        Console.WriteLine("1. WriteIndented: Pretty-print JSON");
        Console.WriteLine("2. JsonPropertyName: Custom JSON property names");
        Console.WriteLine("3. JsonIgnore: Exclude properties from serialization");
        Console.WriteLine("4. Supports nested objects and arrays");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
