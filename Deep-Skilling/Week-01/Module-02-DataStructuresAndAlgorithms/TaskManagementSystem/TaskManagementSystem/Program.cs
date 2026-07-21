using System;

class Task
{
    public int TaskId;
    public string TaskName;
    public string Status;
    public Task Next;

    public Task(int id, string name, string status)
    {
        TaskId = id;
        TaskName = name;
        Status = status;
        Next = null;
    }
}

class TaskLinkedList
{
    private Task head;

    public void AddTask(int id, string name, string status)
    {
        Task newTask = new Task(id, name, status);

        if (head == null)
        {
            head = newTask;
            return;
        }

        Task temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }

        temp.Next = newTask;
    }

    public void SearchTask(int id)
    {
        Task temp = head;

        while (temp != null)
        {
            if (temp.TaskId == id)
            {
                Console.WriteLine($"Found: {temp.TaskName} - {temp.Status}");
                return;
            }

            temp = temp.Next;
        }

        Console.WriteLine("Task not found");
    }

    public void DeleteTask(int id)
    {
        if (head == null)
            return;

        if (head.TaskId == id)
        {
            head = head.Next;
            Console.WriteLine("Task deleted successfully");
            return;
        }

        Task temp = head;

        while (temp.Next != null && temp.Next.TaskId != id)
        {
            temp = temp.Next;
        }

        if (temp.Next != null)
        {
            temp.Next = temp.Next.Next;
            Console.WriteLine("Task deleted successfully");
        }
        else
        {
            Console.WriteLine("Task not found");
        }
    }

    public void Traverse()
    {
        Console.WriteLine("\nTask List:");

        Task temp = head;

        while (temp != null)
        {
            Console.WriteLine($"{temp.TaskId} - {temp.TaskName} - {temp.Status}");
            temp = temp.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        TaskLinkedList tasks = new TaskLinkedList();

        tasks.AddTask(1, "Design UI", "Pending");
        tasks.AddTask(2, "Develop Backend", "In Progress");
        tasks.AddTask(3, "Testing", "Pending");

        tasks.Traverse();

        Console.WriteLine("\nSearching Task ID 2:");
        tasks.SearchTask(2);

        Console.WriteLine("\nDeleting Task ID 2:");
        tasks.DeleteTask(2);

        tasks.Traverse();

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Add = O(n)");
        Console.WriteLine("Search = O(n)");
        Console.WriteLine("Traverse = O(n)");
        Console.WriteLine("Delete = O(n)");
    }
}