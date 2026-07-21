// Program 27: Deadlock Simulation and Resolution
// Demonstrates deadlock conditions and how to prevent them

using System;
using System.Threading;
using System.Threading.Tasks;

class Program27_DeadlockSimulationResolution
{
    class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public object LockObject { get; set; } = new object();

        public Account(int id, decimal balance)
        {
            Id = id;
            Balance = balance;
        }
    }

    static void Main()
    {
        Console.WriteLine("=== DEADLOCK SIMULATION AND RESOLUTION ===\n");

        // Create accounts
        Account accountA = new Account(1, 1000);
        Account accountB = new Account(2, 1000);

        Console.WriteLine("--- DEADLOCK SIMULATION ---");
        Console.WriteLine($"Account A: ${accountA.Balance}");
        Console.WriteLine($"Account B: ${accountB.Balance}\n");

        // Attempt to simulate deadlock
        Console.WriteLine("Starting concurrent transfers that may cause deadlock...");
        Task task1 = Task.Run(() => TransferUnsafe(accountA, accountB, 100));
        Task task2 = Task.Run(() => TransferUnsafe(accountB, accountA, 100));

        // Use timeout to avoid actual deadlock
        bool completed = Task.WaitAll(new[] { task1, task2 }, TimeSpan.FromSeconds(5));
        if (!completed)
        {
            Console.WriteLine("\n⚠ DEADLOCK DETECTED! Tasks did not complete within timeout.");
        }
        else
        {
            Console.WriteLine("Tasks completed (lucky timing - no deadlock this time)");
        }

        // Reset accounts
        accountA.Balance = 1000;
        accountB.Balance = 1000;

        Console.WriteLine("\n--- DEADLOCK PREVENTION (Using Lock Ordering) ---");
        Console.WriteLine($"Account A: ${accountA.Balance}");
        Console.WriteLine($"Account B: ${accountB.Balance}\n");

        Console.WriteLine("Starting concurrent transfers with ordered locks...");
        Task task3 = Task.Run(() => TransferSafe(accountA, accountB, 100));
        Task task4 = Task.Run(() => TransferSafe(accountB, accountA, 100));

        Task.WaitAll(task3, task4);
        Console.WriteLine("✓ Transfer completed successfully!");
        Console.WriteLine($"Account A: ${accountA.Balance}");
        Console.WriteLine($"Account B: ${accountB.Balance}");

        // Deadlock prevention techniques
        Console.WriteLine("\n--- DEADLOCK PREVENTION TECHNIQUES ---");
        Console.WriteLine("1. Lock Ordering: Always acquire locks in the same order");
        Console.WriteLine("2. Timeout: Use Monitor.TryEnter with timeout");
        Console.WriteLine("3. Avoid nested locks: Minimize lock nesting");
        Console.WriteLine("4. Use ReaderWriterLockSlim: For read-heavy scenarios");
        Console.WriteLine("5. Use async/await: Avoid blocking threads");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // UNSAFE: Can cause deadlock
    static void TransferUnsafe(Account from, Account to, decimal amount)
    {
        lock (from.LockObject)
        {
            Console.WriteLine($"[Unsafe] Locked account {from.Id}");
            Thread.Sleep(100); // Simulate processing
            
            lock (to.LockObject)
            {
                Console.WriteLine($"[Unsafe] Locked account {to.Id}");
                from.Balance -= amount;
                to.Balance += amount;
                Thread.Sleep(100);
            }
        }
        Console.WriteLine($"[Unsafe] Transfer completed");
    }

    // SAFE: Using ordered locks to prevent deadlock
    static void TransferSafe(Account from, Account to, decimal amount)
    {
        // Always lock in order of account ID to prevent deadlock
        Account first = from.Id < to.Id ? from : to;
        Account second = from.Id < to.Id ? to : from;

        lock (first.LockObject)
        {
            Console.WriteLine($"[Safe] Locked account {first.Id}");
            Thread.Sleep(100); // Simulate processing
            
            lock (second.LockObject)
            {
                Console.WriteLine($"[Safe] Locked account {second.Id}");
                
                if (from.Id < to.Id)
                {
                    from.Balance -= amount;
                    to.Balance += amount;
                }
                else
                {
                    to.Balance += amount;
                    from.Balance -= amount;
                }
                
                Thread.Sleep(100);
            }
        }
        Console.WriteLine($"[Safe] Transfer completed");
    }
}