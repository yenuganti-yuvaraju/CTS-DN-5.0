// Program 11: Access Modifiers (`public`, `private`, `protected`)
// Demonstrates encapsulation and visibility control

using System;

class BankAccount
{
    // Public: Accessible from anywhere
    public string AccountNumber { get; set; }

    // Private: Accessible only within this class
    private decimal balance;

    // Protected: Accessible in this class and derived classes
    protected string AccountHolder { get; set; }

    // Internal: Accessible within the same assembly
    internal DateTime CreatedDate { get; set; }

    public BankAccount(string accountNumber, string holder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = holder;
        balance = initialBalance;
        CreatedDate = DateTime.Now;
    }

    // Public method: Anyone can call this
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited: ${amount}. New balance: ${balance}");
        }
    }

    // Public method with private helper
    public bool Withdraw(decimal amount)
    {
        if (CanWithdraw(amount))
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: ${amount}. New balance: ${balance}");
            return true;
        }
        Console.WriteLine("Insufficient funds!");
        return false;
    }

    // Private method: Only BankAccount can use this
    private bool CanWithdraw(decimal amount)
    {
        return amount > 0 && amount <= balance;
    }

    // Public property with private setter
    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    // Protected method: Only BankAccount and derived classes can use
    protected void LogTransaction(string transaction)
    {
        Console.WriteLine($"[LOG] {DateTime.Now}: {transaction}");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Account: {AccountNumber}");
        Console.WriteLine($"Holder: {AccountHolder}");
        Console.WriteLine($"Balance: ${balance}");
    }
}

// Derived class can access protected members
class SavingsAccount : BankAccount
{
    public SavingsAccount(string accountNumber, string holder, decimal initialBalance)
        : base(accountNumber, holder, initialBalance)
    {
    }

    public void AddInterest(decimal rate)
    {
        LogTransaction($"Interest applied at {rate}%");
    }
}

class Program11_AccessModifiers
{
    static void Main()
    {
        Console.WriteLine("=== ACCESS MODIFIERS ===\n");

        BankAccount account = new BankAccount("ACC123", "John Doe", 1000);
        account.DisplayInfo();

        Console.WriteLine("\n=== PUBLIC: Accessible ===");
        Console.WriteLine($"Account Number (public): {account.AccountNumber}");

        Console.WriteLine("\n=== BALANCE: Private getter, Public property ===");
        Console.WriteLine($"Balance (public getter): ${account.Balance}");
        // account.Balance = 5000; // ERROR: No public setter

        Console.WriteLine("\n=== TRANSACTIONS ===");
        account.Deposit(500);
        account.Withdraw(200);
        account.Withdraw(2000); // Will fail

        Console.WriteLine("\n=== DERIVED CLASS ===");
        SavingsAccount savings = new SavingsAccount("SAV456", "Jane Smith", 5000);
        savings.Deposit(1000);
        savings.AddInterest(2.5m);

        Console.WriteLine("\n=== ACCESS MODIFIER SUMMARY ===");
        Console.WriteLine("public:    Accessible everywhere");
        Console.WriteLine("private:   Only within the class");
        Console.WriteLine("protected: Within class and derived classes");
        Console.WriteLine("internal:  Within the same assembly");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}