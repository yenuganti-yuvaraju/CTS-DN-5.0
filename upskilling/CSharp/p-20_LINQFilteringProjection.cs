// Program 20: LINQ Filtering and Projection
// Demonstrates language-integrated queries for data manipulation

using System;
using System.Collections.Generic;
using System.Linq;

class Program20_LINQFilteringProjection
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
    }

    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999, Category = "Electronics", Stock = 5 },
            new Product { Id = 2, Name = "Mouse", Price = 25, Category = "Electronics", Stock = 50 },
            new Product { Id = 3, Name = "Desk", Price = 299, Category = "Furniture", Stock = 10 },
            new Product { Id = 4, Name = "Chair", Price = 199, Category = "Furniture", Stock = 15 },
            new Product { Id = 5, Name = "Monitor", Price = 299, Category = "Electronics", Stock = 8 }
        };

        Console.WriteLine("=== LINQ FILTERING AND PROJECTION ===\n");

        // FILTERING
        Console.WriteLine("--- FILTERING ---");

        // Where: Filter items by condition
        var expensiveProducts = products.Where(p => p.Price > 200);
        Console.WriteLine("Products over $200:");
        foreach (var p in expensiveProducts)
        {
            Console.WriteLine($"  {p.Name}: ${p.Price}");
        }

        // Filter by category
        var electronics = products.Where(p => p.Category == "Electronics");
        Console.WriteLine($"\nElectronics: {string.Join(", ", electronics.Select(p => p.Name))}");

        // Filter with multiple conditions
        var lowStockExpensive = products.Where(p => p.Stock < 10 && p.Price > 150);
        Console.WriteLine($"\nLow stock expensive items: {string.Join(", ", lowStockExpensive.Select(p => p.Name))}");

        // PROJECTION
        Console.WriteLine("\n--- PROJECTION ---");

        // Select: Extract specific properties
        var productNames = products.Select(p => p.Name);
        Console.WriteLine($"Product names: {string.Join(", ", productNames)}");

        var productInfo = products.Select(p => $"{p.Name} - ${p.Price}");
        Console.WriteLine("\nProduct info:");
        foreach (var info in productInfo)
        {
            Console.WriteLine($"  {info}");
        }

        // Anonymous type projection
        var productSummary = products.Select(p => new
        {
            p.Name,
            p.Price,
            Status = p.Stock > 10 ? "In Stock" : "Low Stock"
        });

        Console.WriteLine("\nProduct summary:");
        foreach (var summary in productSummary)
        {
            Console.WriteLine($"  {summary.Name}: ${summary.Price} - {summary.Status}");
        }

        // COMBINED FILTERING AND PROJECTION
        Console.WriteLine("\n--- COMBINED FILTERING & PROJECTION ---");

        var cheapElectronics = products
            .Where(p => p.Category == "Electronics" && p.Price < 300)
            .Select(p => new { p.Name, p.Price })
            .OrderBy(p => p.Price);

        Console.WriteLine("Cheap electronics (ordered by price):");
        foreach (var item in cheapElectronics)
        {
            Console.WriteLine($"  {item.Name}: ${item.Price}");
        }

        // AGGREGATION
        Console.WriteLine("\n--- AGGREGATION ---");
        Console.WriteLine($"Total products: {products.Count()}");
        Console.WriteLine($"Average price: ${products.Average(p => p.Price):F2}");
        Console.WriteLine($"Total stock: {products.Sum(p => p.Stock)}");
        Console.WriteLine($"Most expensive: ${products.Max(p => p.Price)}");
        Console.WriteLine($"Least expensive: ${products.Min(p => p.Price)}");

        // GROUP BY
        Console.WriteLine("\n--- GROUP BY ---");
        var groupedByCategory = products.GroupBy(p => p.Category);

        foreach (var group in groupedByCategory)
        {
            Console.WriteLine($"\n{group.Key}:");
            foreach (var product in group)
            {
                Console.WriteLine($"  {product.Name}: ${product.Price}");
            }
        }

        // ORDERING
        Console.WriteLine("\n--- ORDERING ---");
        var sorted = products.OrderByDescending(p => p.Price).Select(p => $"{p.Name}: ${p.Price}");
        Console.WriteLine("Products by price (descending):");
        foreach (var item in sorted)
        {
            Console.WriteLine($"  {item}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}