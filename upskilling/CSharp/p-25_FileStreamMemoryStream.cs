// Program 25: FileStream and MemoryStream
// Demonstrates working with different stream types

using System;
using System.IO;
using System.Text;

class Program25_FileStreamMemoryStream
{
    static void Main()
    {
        Console.WriteLine("=== FILESTREAM AND MEMORYSTREAM ===\n");

        // Create sample data
        string testData = "Hello, World! This is a test of streams in C#.\n" +
                         "Streams are used for reading and writing data.\n" +
                         "They can work with files, memory, or networks.";

        // Working with FileStream
        Console.WriteLine("--- FILESTREAM DEMONSTRATION ---");
        WorkingWithFileStream(testData);

        // Working with MemoryStream
        Console.WriteLine("\n--- MEMORYSTREAM DEMONSTRATION ---");
        WorkingWithMemoryStream(testData);

        // Copy between streams
        Console.WriteLine("\n--- COPYING BETWEEN STREAMS ---");
        CopyBetweenStreams();

        // Reading and writing binary data
        Console.WriteLine("\n--- BINARY DATA HANDLING ---");
        WorkingWithBinaryData();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void WorkingWithFileStream(string data)
    {
        string filePath = "testfile.txt";

        // Write to file using FileStream
        Console.WriteLine($"Writing to file: {filePath}");
        using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            fs.Write(buffer, 0, buffer.Length);
            Console.WriteLine($"Wrote {buffer.Length} bytes");
        }

        // Read from file using FileStream
        Console.WriteLine("Reading from file:");
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024];
            int bytesRead = fs.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine(content);
        }

        // Cleanup
        File.Delete(filePath);
    }

    static void WorkingWithMemoryStream(string data)
    {
        Console.WriteLine("Writing to MemoryStream");
        using (MemoryStream ms = new MemoryStream())
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            ms.Write(buffer, 0, buffer.Length);
            Console.WriteLine($"Wrote {buffer.Length} bytes to memory");

            // Read from MemoryStream
            ms.Position = 0; // Reset position to beginning
            byte[] readBuffer = new byte[1024];
            int bytesRead = ms.Read(readBuffer, 0, readBuffer.Length);
            string content = Encoding.UTF8.GetString(readBuffer, 0, bytesRead);
            Console.WriteLine("Content from memory:");
            Console.WriteLine(content);

            // Get all bytes
            Console.WriteLine($"\nTotal bytes in memory: {ms.Length}");
        }
    }

    static void CopyBetweenStreams()
    {
        string sourceFile = "source.txt";
        string destFile = "destination.txt";
        string testData = "This data will be copied from file to file.";

        // Create source file
        File.WriteAllText(sourceFile, testData);

        // Copy using FileStream
        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
        using (FileStream destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
        {
            sourceStream.CopyTo(destStream);
            Console.WriteLine($"Copied {sourceStream.Length} bytes from {sourceFile} to {destFile}");
        }

        // Verify
        string copiedContent = File.ReadAllText(destFile);
        Console.WriteLine($"Copied content: {copiedContent}");

        // Cleanup
        File.Delete(sourceFile);
        File.Delete(destFile);
    }

    static void WorkingWithBinaryData()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (BinaryWriter writer = new BinaryWriter(ms))
            {
                writer.Write(42);                    // int
                writer.Write(3.14);                  // double
                writer.Write("Hello");               // string
                writer.Write(true);                  // bool
                Console.WriteLine("Written binary data");
            }

            // Read binary data
            ms.Position = 0;
            using (BinaryReader reader = new BinaryReader(ms))
            {
                int intValue = reader.ReadInt32();
                double doubleValue = reader.ReadDouble();
                string stringValue = reader.ReadString();
                bool boolValue = reader.ReadBoolean();

                Console.WriteLine("\nRead binary data:");
                Console.WriteLine($"  Int: {intValue}");
                Console.WriteLine($"  Double: {doubleValue}");
                Console.WriteLine($"  String: {stringValue}");
                Console.WriteLine($"  Bool: {boolValue}");
            }
        }
    }
}