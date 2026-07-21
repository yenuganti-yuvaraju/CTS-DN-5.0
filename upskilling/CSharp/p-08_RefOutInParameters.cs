// Program 08: `ref`, `out`, `in` Parameters
// Demonstrates parameter passing by reference, output, and read-only reference

using System;

class Program08_RefOutInParameters
{
    // REF parameter: Pass by reference, must be initialized before call
    static void IncrementByRef(ref int value)
    {
        value++;
        Console.WriteLine($"Inside IncrementByRef: {value}");
    }

    // OUT parameter: Pass by reference, must be initialized inside method
    static void Divide(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    // IN parameter: Pass by reference, read-only (cannot modify)
    static void PrintLargeStructure(in MyStruct obj)
    {
        Console.WriteLine($"Structure - Name: {obj.Name}, Value: {obj.Value}");
        // obj.Value = 100; // ERROR: Cannot modify 'in' parameter
    }

    struct MyStruct
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    static void Main()
    {
        Console.WriteLine("=== REF PARAMETER ===");
        int num = 10;
        Console.WriteLine($"Before: {num}");
        IncrementByRef(ref num);
        Console.WriteLine($"After: {num}\n");

        Console.WriteLine("=== OUT PARAMETER ===");
        int q, r;
        Divide(17, 5, out q, out r);
        Console.WriteLine($"17 ÷ 5 = {q} remainder {r}\n");

        // Modern syntax (discard unused out parameter)
        Divide(20, 3, out int quotient, out var remainder);
        Console.WriteLine($"20 ÷ 3 = {quotient} remainder {remainder}\n");

        Console.WriteLine("=== IN PARAMETER ===");
        MyStruct obj = new MyStruct { Name = "Test", Value = 42 };
        PrintLargeStructure(in obj);
        Console.WriteLine($"Original structure unchanged: Value = {obj.Value}\n");

        Console.WriteLine("=== COMPARISON ===");
        Console.WriteLine("REF:  Must be initialized, can be read and modified");
        Console.WriteLine("OUT:  Must be initialized in method, passed as output");
        Console.WriteLine("IN:   Read-only reference, avoids copying large structs");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}