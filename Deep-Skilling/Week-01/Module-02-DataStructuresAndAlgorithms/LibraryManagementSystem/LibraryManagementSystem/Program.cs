using System;

class Book
{
    public int BookId;
    public string Title;
    public string Author;

    public Book(int id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
    }
}

class Program
{
    static int LinearSearch(Book[] books, string title)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

    static int BinarySearch(Book[] books, string title)
    {
        int low = 0;
        int high = books.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            int result = string.Compare(
                books[mid].Title,
                title,
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
        Book[] books =
        {
            new Book(1, "C Programming", "Dennis Ritchie"),
            new Book(2, "Data Structures", "Mark Allen"),
            new Book(3, "Java Programming", "James Gosling"),
            new Book(4, "Python Basics", "Guido van Rossum"),
            new Book(5, "Web Development", "Tim Berners-Lee")
        };

        string searchTitle = "Java Programming";

        Console.WriteLine("Linear Search:");
        int linearResult = LinearSearch(books, searchTitle);

        if (linearResult != -1)
            Console.WriteLine($"Book Found: {books[linearResult].Title}");
        else
            Console.WriteLine("Book Not Found");

        Console.WriteLine("\nBinary Search:");
        int binaryResult = BinarySearch(books, searchTitle);

        if (binaryResult != -1)
            Console.WriteLine($"Book Found: {books[binaryResult].Title}");
        else
            Console.WriteLine("Book Not Found");

        Console.WriteLine("\nAnalysis:");
        Console.WriteLine("Linear Search Time Complexity = O(n)");
        Console.WriteLine("Binary Search Time Complexity = O(log n)");
    }
}