using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RetailInventory.Data;
using RetailInventory.Models;

Console.WriteLine("Step 1");

var builder = Host.CreateApplicationBuilder(args);

Console.WriteLine("Step 2");

builder.Services.AddDbContext<RetailDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RetailDbConnection")));

Console.WriteLine("Step 3");

var app = builder.Build();

Console.WriteLine("Step 4");

using var scope = app.Services.CreateScope();

Console.WriteLine("Step 5");

var context = scope.ServiceProvider.GetRequiredService<RetailDbContext>();

Console.WriteLine("Step 6");

context.Database.EnsureCreated();

Console.WriteLine("Step 7");

if (!context.Categories.Any())
{
    Console.WriteLine("Step 8");

    var electronics = new Category
    {
        CategoryName = "Electronics"
    };

    var groceries = new Category
    {
        CategoryName = "Groceries"
    };

    context.Categories.AddRange(electronics, groceries);
    context.SaveChanges();

    Console.WriteLine("Step 9");

    context.Products.AddRange(
        new Product
        {
            ProductName = "Laptop",
            Price = 50000m,
            Stock = 10,
            CategoryId = electronics.CategoryId
        },
        new Product
        {
            ProductName = "Rice Bag",
            Price = 1200m,
            Stock = 25,
            CategoryId = groceries.CategoryId
        });

    context.SaveChanges();

    Console.WriteLine("Step 10");
}

Console.WriteLine("Initial data inserted successfully.");
Console.ReadKey();