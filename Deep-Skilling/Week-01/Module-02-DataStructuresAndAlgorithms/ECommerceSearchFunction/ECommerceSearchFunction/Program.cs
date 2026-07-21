using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class Program
{
    static int LinearSearch(Product[] products, string searchName)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    static int BinarySearch(Product[] products, string searchName)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            int result = string.Compare(
                products[mid].ProductName,
                searchName,
                StringComparison.OrdinalIgnoreCase);

            if (result == 0)
                return mid;
            else if (result < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }

    static void Main()
    {
        Product[] products =
        {
            new Product(101, "Keyboard", "Electronics"),
            new Product(102, "Laptop", "Electronics"),
            new Product(103, "Mouse", "Electronics"),
            new Product(104, "Phone", "Electronics"),
            new Product(105, "Tablet", "Electronics")
        };

        string searchItem = "Mouse";

        int linearResult = LinearSearch(products, searchItem);
        Console.WriteLine("Linear Search:");

        if (linearResult != -1)
            Console.WriteLine($"Found {searchItem} at position {linearResult}");
        else
            Console.WriteLine("Product not found");

        int binaryResult = BinarySearch(products, searchItem);
        Console.WriteLine("\nBinary Search:");

        if (binaryResult != -1)
            Console.WriteLine($"Found {searchItem} at position {binaryResult}");
        else
            Console.WriteLine("Product not found");

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Linear Search Time Complexity = O(n)");
        Console.WriteLine("Binary Search Time Complexity = O(log n)");
        Console.WriteLine("Binary Search is faster for large sorted datasets.");
    }
}