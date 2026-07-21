// Program 23: Async File Upload Simulation
// Demonstrates asynchronous operations and Task-based patterns

using System;
using System.Threading;
using System.Threading.Tasks;

class Program23_AsyncFileUploadSimulation
{
    class FileUploadResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int BytesUploaded { get; set; }
        public TimeSpan Duration { get; set; }
    }

    static async Task Main()
    {
        Console.WriteLine("=== ASYNC FILE UPLOAD SIMULATION ===\n");

        // Single file upload
        Console.WriteLine("--- SINGLE FILE UPLOAD ---");
        var result1 = await UploadFileAsync("document.pdf", 5000);
        Console.WriteLine($"Upload: {result1.Message}");
        Console.WriteLine($"Bytes: {result1.BytesUploaded}, Duration: {result1.Duration.TotalSeconds:F2}s\n");

        // Simulate multiple file uploads sequentially
        Console.WriteLine("--- SEQUENTIAL UPLOADS ---");
        var files = new[] { "file1.txt", "file2.docx", "file3.zip" };
        
        foreach (var file in files)
        {
            var result = await UploadFileAsync(file, 2000);
            Console.WriteLine($"{file}: {result.Message}");
        }

        // Multiple file uploads in parallel
        Console.WriteLine("\n--- PARALLEL UPLOADS ---");
        var uploadTasks = new[]
        {
            UploadFileAsync("photo1.jpg", 3000),
            UploadFileAsync("photo2.jpg", 3000),
            UploadFileAsync("photo3.jpg", 3000)
        };

        var results = await Task.WhenAll(uploadTasks);
        foreach (var result in results)
        {
            Console.WriteLine($"Uploaded: {result.BytesUploaded} bytes in {result.Duration.TotalSeconds:F2}s");
        }

        // Upload with timeout
        Console.WriteLine("\n--- UPLOAD WITH TIMEOUT ---");
        try
        {
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
            var timeoutResult = await UploadFileWithCancellationAsync("largefile.iso", 10000, cts.Token);
            Console.WriteLine(timeoutResult.Message);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Upload cancelled: Operation exceeded timeout");
        }

        // Upload with progress tracking
        Console.WriteLine("\n--- UPLOAD WITH PROGRESS ---");
        await UploadFileWithProgressAsync("video.mp4", 8000);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static async Task<FileUploadResult> UploadFileAsync(string filename, int sizeBytes)
    {
        var startTime = DateTime.Now;
        Console.WriteLine($"Starting upload: {filename}");

        // Simulate async operation
        await Task.Delay(sizeBytes / 100); // Simulate network delay

        var result = new FileUploadResult
        {
            Success = true,
            Message = $"Successfully uploaded {filename}",
            BytesUploaded = sizeBytes,
            Duration = DateTime.Now - startTime
        };

        return result;
    }

    static async Task<FileUploadResult> UploadFileWithCancellationAsync(
        string filename, int sizeBytes, CancellationToken cancellationToken)
    {
        var startTime = DateTime.Now;
        Console.WriteLine($"Starting upload with cancellation: {filename}");

        try
        {
            await Task.Delay(sizeBytes / 100, cancellationToken);

            return new FileUploadResult
            {
                Success = true,
                Message = $"Successfully uploaded {filename}",
                BytesUploaded = sizeBytes,
                Duration = DateTime.Now - startTime
            };
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine($"Upload of {filename} was cancelled");
            throw;
        }
    }

    static async Task UploadFileWithProgressAsync(string filename, int totalSize)
    {
        Console.WriteLine($"Uploading {filename} ({totalSize} bytes)");

        int chunkSize = totalSize / 10; // 10% chunks
        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(100); // Simulate upload chunk
            int progress = (i + 1) * 10;
            Console.WriteLine($"  Progress: {progress}% ({(i + 1) * chunkSize} / {totalSize} bytes)");
        }

        Console.WriteLine($"  ✓ {filename} uploaded successfully");
    }
}