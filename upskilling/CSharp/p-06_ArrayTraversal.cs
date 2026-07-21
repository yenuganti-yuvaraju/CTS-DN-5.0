// Program 06: Array Traversal using `for`, `foreach`, `while`, `do-while`
// Demonstrates different loop constructs for array iteration

using System;

class Program06_ArrayTraversal
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        Console.WriteLine("=== FOR LOOP ===");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Index {i}: {numbers[i]}");
        }

        Console.WriteLine("\n=== FOREACH LOOP ===");
        foreach (int num in numbers)
        {
            Console.WriteLine($"Value: {num}");
        }

        Console.WriteLine("\n=== WHILE LOOP ===");
        int index = 0;
        while (index < numbers.Length)
        {
            Console.WriteLine($"Position {index}: {numbers[index]}");
            index++;
        }

        Console.WriteLine("\n=== DO-WHILE LOOP ===");
        int count = 0;
        do
        {
            Console.WriteLine($"Element {count}: {numbers[count]}");
            count++;
        } while (count < numbers.Length);

        Console.WriteLine("\n=== REVERSE TRAVERSAL (FOR LOOP) ===");
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.WriteLine($"Index {i}: {numbers[i]}");
        }

        Console.WriteLine("\n=== MULTIDIMENSIONAL ARRAY ===");
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write($"{matrix[row, col],3} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\n=== JAGGED ARRAY ===");
        int[][] jagged = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 4, 5 },
            new int[] { 6 }
        };

        foreach (int[] row in jagged)
        {
            foreach (int value in row)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}