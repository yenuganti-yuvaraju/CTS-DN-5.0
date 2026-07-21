using System;

class Order
{
    public int OrderId;
    public string CustomerName;
    public double TotalPrice;

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }
}

class Program
{
    static void BubbleSort(Order[] orders)
    {
        int n = orders.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    Order temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(orders, low, high);

            QuickSort(orders, low, pi - 1);
            QuickSort(orders, pi + 1, high);
        }
    }

    static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice < pivot)
            {
                i++;

                Order temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        Order temp1 = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = temp1;

        return i + 1;
    }

    static void Display(Order[] orders)
    {
        foreach (Order o in orders)
        {
            Console.WriteLine($"{o.OrderId} - {o.CustomerName} - ₹{o.TotalPrice}");
        }
    }

    static void Main()
    {
        Order[] orders =
        {
            new Order(1, "Barnabas", 4500),
            new Order(2, "John", 1200),
            new Order(3, "David", 7800),
            new Order(4, "Sam", 3000)
        };

        Console.WriteLine("Bubble Sort:");
        BubbleSort(orders);
        Display(orders);

        Console.WriteLine("\nQuick Sort:");
        QuickSort(orders, 0, orders.Length - 1);
        Display(orders);

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Bubble Sort Time Complexity = O(n^2)");
        Console.WriteLine("Quick Sort Average Time Complexity = O(n log n)");
        Console.WriteLine("Quick Sort is generally faster for large datasets.");
    }
}