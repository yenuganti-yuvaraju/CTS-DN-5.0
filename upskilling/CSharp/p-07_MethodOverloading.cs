// Program 07: Method Overloading
// Demonstrates multiple method signatures with the same name but different parameters

using System;

class Calculator
{
    // Overload 1: Two integers
    public int Add(int a, int b)
    {
        Console.WriteLine($"Adding integers: {a} + {b}");
        return a + b;
    }

    // Overload 2: Two doubles
    public double Add(double a, double b)
    {
        Console.WriteLine($"Adding doubles: {a} + {b}");
        return a + b;
    }

    // Overload 3: Three integers
    public int Add(int a, int b, int c)
    {
        Console.WriteLine($"Adding three integers: {a} + {b} + {c}");
        return a + b + c;
    }

    // Overload 4: String concatenation
    public string Add(string a, string b)
    {
        Console.WriteLine($"Concatenating strings: '{a}' + '{b}'");
        return a + b;
    }

    // Overload 5: Array of integers
    public int Add(int[] numbers)
    {
        Console.WriteLine($"Adding array of {numbers.Length} integers");
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    // Overload 6: Variable length arguments (params)
    public int Add(params int[] numbers)
    {
        Console.WriteLine($"Adding {numbers.Length} variable arguments");
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }
}

class Program07_MethodOverloading
{
    static void Main()
    {
        Calculator calc = new Calculator();

        Console.WriteLine("=== METHOD OVERLOADING ===\n");

        // Call different overloads
        int result1 = calc.Add(5, 10);
        Console.WriteLine($"Result: {result1}\n");

        double result2 = calc.Add(5.5, 10.3);
        Console.WriteLine($"Result: {result2}\n");

        int result3 = calc.Add(5, 10, 15);
        Console.WriteLine($"Result: {result3}\n");

        string result4 = calc.Add("Hello", " World");
        Console.WriteLine($"Result: {result4}\n");

        int[] numbers = { 1, 2, 3, 4, 5 };
        int result5 = calc.Add(numbers);
        Console.WriteLine($"Result: {result5}\n");

        int result6 = calc.Add(10, 20, 30, 40, 50);
        Console.WriteLine($"Result: {result6}\n");

        Console.WriteLine("Benefits of Method Overloading:");
        Console.WriteLine("1. Same method name for similar operations");
        Console.WriteLine("2. Improved code readability");
        Console.WriteLine("3. Flexible parameter types and counts");
        Console.WriteLine("4. Determined at compile-time (static dispatch)");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}