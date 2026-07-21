using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }

    public Product(int id, string name, int qty)
    {
        ProductId = id;
        ProductName = name;
        Quantity = qty;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>();

        products.Add(new Product(101, "Laptop", 10));
        products.Add(new Product(102, "Mouse", 50));
        products.Add(new Product(103, "Keyboard", 30));

        Console.WriteLine("Inventory Management System");
        Console.WriteLine("---------------------------");

        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.ProductId}, Name: {p.ProductName}, Qty: {p.Quantity}");
        }
    }
}