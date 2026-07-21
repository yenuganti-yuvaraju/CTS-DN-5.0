using System;

class Program
{
    static double Forecast(double currentValue, double growthRate, int years)
    {
        if (years == 0)
            return currentValue;

        return Forecast(currentValue * (1 + growthRate), growthRate, years - 1);
    }

    static void Main()
    {
        double currentValue = 10000;
        double growthRate = 0.10; // 10%
        int years = 5;

        double futureValue = Forecast(currentValue, growthRate, years);

        Console.WriteLine("Financial Forecasting");
        Console.WriteLine("---------------------");
        Console.WriteLine("Current Value : " + currentValue);
        Console.WriteLine("Growth Rate   : " + (growthRate * 100) + "%");
        Console.WriteLine("Years         : " + years);
        Console.WriteLine("Future Value  : " + futureValue);

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Recursive Time Complexity = O(n)");
        Console.WriteLine("Space Complexity = O(n)");
        Console.WriteLine("Optimization: Use iteration or memoization to reduce recursion overhead.");
    }
}