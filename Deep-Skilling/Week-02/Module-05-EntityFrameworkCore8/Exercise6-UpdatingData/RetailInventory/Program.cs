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

Console.WriteLine("===============================");
Console.WriteLine(" Exercise 6 - Updating Data");
Console.WriteLine("===============================\n");

Console.WriteLine("Searching for Product with ID = 1...\n");

var product = context.Products.Find(1);

if (product != null)
{
    Console.WriteLine("Product Found!");

    Console.WriteLine($"Old Name  : {product.ProductName}");
    Console.WriteLine($"Old Price : {product.Price}");
    Console.WriteLine($"Old Stock : {product.Stock}");

    product.Price = 55000;
    product.Stock = 15;

    context.SaveChanges();

    Console.WriteLine("\nProduct Updated Successfully!\n");

    Console.WriteLine($"New Name  : {product.ProductName}");
    Console.WriteLine($"New Price : {product.Price}");
    Console.WriteLine($"New Stock : {product.Stock}");
}
else
{
    Console.WriteLine("Product not found.");
}