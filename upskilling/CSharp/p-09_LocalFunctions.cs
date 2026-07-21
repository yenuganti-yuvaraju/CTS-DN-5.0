// Program 09: Local Functions (Factorial)
// Demonstrates nested functions defined within a method scope

using System;

class Program09_LocalFunctions
{
    static void Main()
    {
        Console.WriteLine("=== LOCAL FUNCTIONS ===\n");

        // Example 1: Factorial using local function
        Console.WriteLine("Factorial Examples:");
        CalculateFactorials();

        // Example 2: Local function with recursion
        Console.WriteLine("\n=== FIBONACCI SEQUENCE ===");
        PrintFibonacciSequence(10);

        // Example 3: Local function with validation
        Console.WriteLine("\n=== VALIDATION EXAMPLE ===");
        ValidateAndProcess();

        // Example 4: Local function closure (accessing outer scope)
        Console.WriteLine("\n=== CLOSURE EXAMPLE ===");
        DemonstrateClosures();
    }

    static void CalculateFactorials()
    {
        // Local function definition
        long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1); // Recursive call
        }

        // Using the local function
        for (int i = 0; i <= 7; i++)
        {
            Console.WriteLine($"{i}! = {Factorial(i)}");
        }
    }

    static void PrintFibonacciSequence(int count)
    {
        int GenerateFibonacci(int index)
        {
            if (index <= 1)
                return index;
            return GenerateFibonacci(index - 1) + GenerateFibonacci(index - 2);
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"{GenerateFibonacci(i)} ");
        }
        Console.WriteLine();
    }

    static void ValidateAndProcess()
    {
        // Local validation function
        bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        string[] emails = { "user@example.com", "invalid.email", "test@domain.co.uk" };

        foreach (var email in emails)
        {
            bool isValid = IsValidEmail(email);
            Console.WriteLine($"{email}: {(isValid ? "Valid" : "Invalid")}");
        }
    }

    static void DemonstrateClosures()
    {
        int outerVariable = 10;

        // Local function accessing outer scope
        void IncrementOuter()
        {
            outerVariable++;
            Console.WriteLine($"Incremented outerVariable: {outerVariable}");
        }

        void PrintOuter()
        {
            Console.WriteLine($"Current outerVariable: {outerVariable}");
        }

        PrintOuter();
        IncrementOuter();
        PrintOuter();
        IncrementOuter();
        PrintOuter();
    }
}