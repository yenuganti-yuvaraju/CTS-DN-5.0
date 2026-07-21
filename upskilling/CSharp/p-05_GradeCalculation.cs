// Program 05: Grade Calculation using `if`, `switch`, Pattern Matching
// Demonstrates conditional logic with multiple approaches

using System;

class Program05_GradeCalculation
{
    // Traditional if-else approach
    static char GetGradeIfElse(int score)
    {
        if (score >= 90)
            return 'A';
        else if (score >= 80)
            return 'B';
        else if (score >= 70)
            return 'C';
        else if (score >= 60)
            return 'D';
        else
            return 'F';
    }

    // Switch statement approach
    static char GetGradeSwitch(int score)
    {
        return score switch
        {
            >= 90 => 'A',
            >= 80 => 'B',
            >= 70 => 'C',
            >= 60 => 'D',
            _ => 'F'
        };
    }

    // Pattern matching with when clause
    static string GetGradeDescription(int score)
    {
        return score switch
        {
            >= 90 and < 100 => "Excellent!",
            >= 80 and < 90 => "Very Good!",
            >= 70 and < 80 => "Good!",
            >= 60 and < 70 => "Satisfactory",
            >= 0 and < 60 => "Needs Improvement",
            _ => "Invalid Score"
        };
    }

    static void Main()
    {
        int[] testScores = { 95, 87, 75, 62, 45 };

        Console.WriteLine("=== GRADE CALCULATION ===\n");
        Console.WriteLine($"{"Score",-10} {"If-Else",-10} {"Switch",-10} {"Description",-20}");
        Console.WriteLine(new string('-', 50));

        foreach (int score in testScores)
        {
            char gradeIfElse = GetGradeIfElse(score);
            char gradeSwitch = GetGradeSwitch(score);
            string description = GetGradeDescription(score);

            Console.WriteLine($"{score,-10} {gradeIfElse,-10} {gradeSwitch,-10} {description,-20}");
        }

        Console.WriteLine("\n=== PATTERN MATCHING EXAMPLES ===");
        
        // Advanced pattern matching
        object[] values = { 42, "Hello", 3.14, true, null };
        
        foreach (var value in values)
        {
            string result = value switch
            {
                int i => $"Integer: {i}",
                string s => $"String: {s}",
                double d => $"Double: {d:F2}",
                bool b => $"Boolean: {b}",
                null => "Null value",
                _ => "Unknown type"
            };
            Console.WriteLine(result);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}