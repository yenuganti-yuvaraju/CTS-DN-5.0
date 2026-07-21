// Program 30: ADO.NET CRUD Operations
// Demonstrates basic Create, Read, Update, Delete database operations

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

class Program30_ADONETCRUD
{
    // Connection string (example - update with your actual connection)
    private const string ConnectionString = "Server=.;Database=TestDB;Integrated Security=true;";

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    static void Main()
    {
        Console.WriteLine("=== ADO.NET CRUD OPERATIONS ===\n");

        // NOTE: This is a demonstration. In production, use Entity Framework or Dapper
        Console.WriteLine("Note: This is a demonstration of ADO.NET patterns.");
        Console.WriteLine("Update the connection string and ensure SQL Server is available.\n");

        Console.WriteLine("--- CRUD OPERATIONS ---");
        Console.WriteLine("CREATE: Insert new product");
        Console.WriteLine("READ:   Retrieve product data");
        Console.WriteLine("UPDATE: Modify existing product");
        Console.WriteLine("DELETE: Remove product\n");

        DemonstrateCRUDPatterns();

        Console.WriteLine("\n--- BEST PRACTICES ---");
        DisplayBestPractices();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DemonstrateCRUDPatterns()
    {
        // Note: These are pseudo-demonstrations since we don't have a real database

        Console.WriteLine("Example Product (In-Memory):");
        var product = new Product 
        { 
            Id = 1, 
            Name = "Laptop", 
            Price = 999.99m, 
            Stock = 5 
        };

        Console.WriteLine($"  ID: {product.Id}");
        Console.WriteLine($"  Name: {product.Name}");
        Console.WriteLine($"  Price: ${product.Price}");
        Console.WriteLine($"  Stock: {product.Stock}");

        Console.WriteLine("\n--- CREATE (INSERT) PATTERN ---");
        string createQuery = @"INSERT INTO Products (Name, Price, Stock)
                             VALUES (@name, @price, @stock)";
        Console.WriteLine(createQuery);
        Console.WriteLine("Parameters: @name, @price, @stock");

        Console.WriteLine("\n--- READ (SELECT) PATTERN ---");
        string readQuery = "SELECT * FROM Products WHERE Id = @id";
        Console.WriteLine(readQuery);

        Console.WriteLine("\n--- UPDATE PATTERN ---");
        string updateQuery = @"UPDATE Products SET 
                             Name = @name, 
                             Price = @price, 
                             Stock = @stock 
                             WHERE Id = @id";
        Console.WriteLine(updateQuery);

        Console.WriteLine("\n--- DELETE PATTERN ---");
        string deleteQuery = "DELETE FROM Products WHERE Id = @id";
        Console.WriteLine(deleteQuery);
    }

    static void DisplayBestPractices()
    {
        Console.WriteLine("\n1. USE PARAMETERIZED QUERIES");
        Console.WriteLine("   ✓ Prevents SQL injection");
        Console.WriteLine("   ✓ Improves performance");
        Console.WriteLine("   Bad:  \"SELECT * FROM Products WHERE Name = '\" + name + \"'\"");
        Console.WriteLine("   Good: cmd.Parameters.AddWithValue(\"@name\", name);\n");

        Console.WriteLine("2. USE USING STATEMENTS");
        Console.WriteLine("   ✓ Ensures proper resource disposal");
        Console.WriteLine("   using (SqlConnection conn = new SqlConnection(connectionString))");
        Console.WriteLine("   using (SqlCommand cmd = new SqlCommand(query, conn))\n");

        Console.WriteLine("3. ERROR HANDLING");
        Console.WriteLine("   try-catch SqlException for database errors");
        Console.WriteLine("   Handle connection failures gracefully\n");

        Console.WriteLine("4. CONNECTION POOLING");
        Console.WriteLine("   ✓ Reuse connections for better performance");
        Console.WriteLine("   ✓ Configured via connection string\n");

        Console.WriteLine("5. CONSIDER ORM FRAMEWORKS");
        Console.WriteLine("   ✓ Entity Framework: Easier, more maintainable");
        Console.WriteLine("   ✓ Dapper: Lightweight, performant");
        Console.WriteLine("   ✓ NHibernate: Full-featured ORM\n");

        Console.WriteLine("6. ASYNC OPERATIONS");
        Console.WriteLine("   ✓ Use async methods for better scalability");
        Console.WriteLine("   await cmd.ExecuteNonQueryAsync();\n");

        Console.WriteLine("7. DATA VALIDATION");
        Console.WriteLine("   ✓ Validate input before database operations");
        Console.WriteLine("   ✓ Use constraints in database");
        Console.WriteLine("   ✓ Sanitize user input\n");

        Console.WriteLine("8. TRANSACTIONS");
        Console.WriteLine("   ✓ Ensure data consistency");
        Console.WriteLine("   ✓ Rollback on errors");
        Console.WriteLine("   using (SqlTransaction transaction = conn.BeginTransaction())\n");

        Console.WriteLine("EXAMPLE CODE:");
        DisplayExampleCode();
    }

    static void DisplayExampleCode()
    {
        string example = @"
using (SqlConnection conn = new SqlConnection(connectionString))
{
    conn.Open();
    
    // CREATE
    string insertQuery = ""INSERT INTO Products (Name, Price) VALUES (@name, @price)"";
    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
    {
        cmd.Parameters.AddWithValue(""@name"", ""Laptop"");
        cmd.Parameters.AddWithValue(""@price"", 999.99);
        cmd.ExecuteNonQuery();
    }
    
    // READ
    string selectQuery = ""SELECT * FROM Products WHERE Name = @name"";
    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
    {
        cmd.Parameters.AddWithValue(""@name"", ""Laptop"");
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader[""Name""].ToString());
            }
        }
    }
    
    // UPDATE
    string updateQuery = ""UPDATE Products SET Price = @price WHERE Name = @name"";
    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
    {
        cmd.Parameters.AddWithValue(""@price"", 899.99);
        cmd.Parameters.AddWithValue(""@name"", ""Laptop"");
        cmd.ExecuteNonQuery();
    }
    
    // DELETE
    string deleteQuery = ""DELETE FROM Products WHERE Name = @name"";
    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
    {
        cmd.Parameters.AddWithValue(""@name"", ""Laptop"");
        cmd.ExecuteNonQuery();
    }
}";
        Console.WriteLine(example);
    }
}