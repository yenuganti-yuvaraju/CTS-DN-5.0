// Program 26: Race Conditions and Multi-threading
// Demonstrates threading issues and proper synchronization

using System;
using System.Threading;
using System.Threading.Tasks;

class Program26_RaceConditionsMultiThreading
{
    class BankAccount
    {
        private decimal balance;
        private object lockObject = new object();

        public BankAccount(decimal initialBalance)
        {
            balance = initialBalance;
        }

        // UNSAFE: Race condition without synchronization
        public void WithdrawUnsafe(decimal amount)
        {
            if (balance >= amount)
            {
                Thread.Sleep(10); // Simulate processing delay
                balance -= amount;
            }
        }

        // SAFE: Using lock for thread safety
        public void WithdrawSafe(decimal amount)
        {
            lock (lockObject)
            {
                if (balance >= amount)
                {
                    Thread.Sleep(10); // Simulate processing delay
                    balance -= amount;
                }
            }
        }

        public decimal GetBalance()
        {
            lock (lockObject)
            {
                return balance;
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Balance: ${GetBalance():F2}");
        }
    }

    static void Main()
    {
        Console.WriteLine("=== RACE CONDITIONS AND MULTI-THREADING ===\n");

        // Demonstrate race condition
        Console.WriteLine("--- RACE CONDITION (UNSAFE) ---");
        DemonstrateRaceCondition();

        // Demonstrate thread safety
        Console.WriteLine("\n--- THREAD SAFETY (WITH LOCK) ---");
        DemonstrateThreadSafety();

        // Thread creation and management
        Console.WriteLine("\n--- THREAD CREATION ---");
        DemonstrateThreadCreation();

        // Tasks (modern alternative)
        Console.WriteLine("\n--- USING TASKS ---");
        DemonstrateWithTasks();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DemonstrateRaceCondition()
    {
        BankAccount account = new BankAccount(1000);
        Console.WriteLine("Initial balance: $1000");
        Console.WriteLine("Starting 10 withdrawal tasks of $100 each...\n");

        Task[] tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(() => account.WithdrawUnsafe(100));
        }

        Task.WaitAll(tasks);
        Console.WriteLine($"Expected balance: $0");
        account.DisplayBalance();
        Console.WriteLine("(Note: Balance may be higher due to race condition!)");
    }

    static void DemonstrateThreadSafety()
    {
        BankAccount account = new BankAccount(1000);
        Console.WriteLine("Initial balance: $1000");
        Console.WriteLine("Starting 10 withdrawal tasks of $100 each (with lock)...\n");

        Task[] tasks = new Task[10];
        for (int i = 0; i < 10; i++)
        {
            tasks[i] = Task.Run(() => account.WithdrawSafe(100));
        }

        Task.WaitAll(tasks);
        Console.WriteLine($"Expected balance: $0");
        account.DisplayBalance();
        Console.WriteLine("(Balance is correct due to thread synchronization!)");
    }

    static void DemonstrateThreadCreation()
    {
        Console.WriteLine("Creating and starting threads:");

        Thread thread1 = new Thread(() => DoWork("Thread 1"));
        Thread thread2 = new Thread(() => DoWork("Thread 2"));
        Thread thread3 = new Thread(() => DoWork("Thread 3"));

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine("All threads completed");
    }

    static void DemonstrateWithTasks()
    {
        Console.WriteLine("Creating and starting tasks:");

        Task task1 = Task.Run(() => DoWork("Task 1"));
        Task task2 = Task.Run(() => DoWork("Task 2"));
        Task task3 = Task.Run(() => DoWork("Task 3"));

        Task.WaitAll(task1, task2, task3);
        Console.WriteLine("All tasks completed");
    }

    static void DoWork(string name)
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"{name}: Working... ({i}/3)");
            Thread.Sleep(500);
        }
        Console.WriteLine($"{name}: Done!");
    }
}