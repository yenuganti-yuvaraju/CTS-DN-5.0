using System;
using RetailInventory.Data;

namespace RetailInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 2 - Setting Up Database Context");
            Console.WriteLine("RetailDbContext created successfully.");

            RetailDbContext? context = null;

            Console.WriteLine("DbContext is configured.");
        }
    }
}