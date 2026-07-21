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
Console.WriteLine(" Exercise 7 - Deleting Data");
Console.WriteLine("===============================\n");

Console.WriteLine("Searching for Product with ID = 2...\n");

var product = context.Products.Find(1);

if (product != null)
{
    Console.WriteLine("Product Found!");

    Console.WriteLine($"Name  : {product.ProductName}");
    Console.WriteLine($"Price : {product.Price}");
    Console.WriteLine($"Stock : {product.Stock}");

    context.Products.Remove(product);
    context.SaveChanges();

    Console.WriteLine("\nProduct Deleted Successfully!");
}
else
{
    Console.WriteLine("Product not found.");
}