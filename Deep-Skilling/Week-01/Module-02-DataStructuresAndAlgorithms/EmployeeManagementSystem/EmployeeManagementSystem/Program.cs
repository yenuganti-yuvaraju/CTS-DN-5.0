using System;

class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }
}

class Program
{
    static Employee[] employees = new Employee[10];
    static int count = 0;

    static void AddEmployee(Employee emp)
    {
        if (count < employees.Length)
        {
            employees[count++] = emp;
        }
    }

    static void SearchEmployee(int id)
    {
        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine($"Found: {employees[i].Name}, {employees[i].Position}, Salary: {employees[i].Salary}");
                return;
            }
        }
        Console.WriteLine("Employee not found");
    }

    static void TraverseEmployees()
    {
        Console.WriteLine("\nEmployee Records:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{employees[i].EmployeeId} - {employees[i].Name} - {employees[i].Position} - ₹{employees[i].Salary}");
        }
    }

    static void DeleteEmployee(int id)
    {
        int index = -1;

        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Employee not found");
            return;
        }

        for (int i = index; i < count - 1; i++)
        {
            employees[i] = employees[i + 1];
        }

        count--;
        Console.WriteLine("Employee deleted successfully");
    }

    static void Main()
    {
        AddEmployee(new Employee(101, "Barnabas", "Developer", 50000));
        AddEmployee(new Employee(102, "John", "Tester", 40000));
        AddEmployee(new Employee(103, "David", "Manager", 70000));

        TraverseEmployees();

        Console.WriteLine("\nSearching Employee ID 102:");
        SearchEmployee(102);

        Console.WriteLine("\nDeleting Employee ID 102:");
        DeleteEmployee(102);

        TraverseEmployees();

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Add Operation = O(1)");
        Console.WriteLine("Search Operation = O(n)");
        Console.WriteLine("Traverse Operation = O(n)");
        Console.WriteLine("Delete Operation = O(n)");
    }
}