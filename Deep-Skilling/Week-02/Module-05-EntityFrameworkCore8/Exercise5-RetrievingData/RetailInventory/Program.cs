using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailInventory.Data;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<RetailDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RetailDbConnection")));

var app = builder.Build();

using var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<RetailDbContext>();

Console.WriteLine("=================================");
Console.WriteLine(" Exercise 5 - Retrieving Data");
Console.WriteLine("=================================\n");

Console.WriteLine("All Products:\n");

var products = context.Products.ToList();

foreach (var product in products)
{
    Console.WriteLine($"ID : {product.ProductId}");
    Console.WriteLine($"Name : {product.ProductName}");
    Console.WriteLine($"Price : {product.Price}");
    Console.WriteLine($"Stock : {product.Stock}");
    Console.WriteLine("---------------------------");
}

Console.WriteLine("\nFinding Product with ID = 1\n");

var productById = context.Products.Find(1);

if (productById != null)
{
    Console.WriteLine($"Product Found : {productById.ProductName}");
}
else
{
    Console.WriteLine("Product not found.");
}

Console.WriteLine("\nFirst Product with Price > 1000\n");

var expensiveProduct = context.Products
    .FirstOrDefault(p => p.Price > 1000);

if (expensiveProduct != null)
{
    Console.WriteLine($"Product : {expensiveProduct.ProductName}");
}
else
{
    Console.WriteLine("No matching product.");
}