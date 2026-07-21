// Program 01: Set Up Development Environment (Hello World)
// Demonstrates basic C# console application setup and simple output

using System;

class Program01_HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Welcome to C# Development!");
        
        // Display system information
        Console.WriteLine($"\nRuntime: {System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
        Console.WriteLine($"OS: {System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}