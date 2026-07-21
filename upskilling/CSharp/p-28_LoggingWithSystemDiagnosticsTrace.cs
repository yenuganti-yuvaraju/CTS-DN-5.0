// Program 28: Logging with `System.Diagnostics.Trace`
// Demonstrates system diagnostics and trace logging

using System;
using System.Diagnostics;
using System.IO;

class Program28_LoggingWithSystemDiagnosticsTrace
{
    static void Main()
    {
        Console.WriteLine("=== LOGGING WITH SYSTEM.DIAGNOSTICS.TRACE ===\n");

        // Set up trace listeners
        SetupTraceListeners();

        Console.WriteLine("--- TRACE OPERATIONS ---\n");

        // Basic trace operations
        Trace.WriteLine("Application started");
        Trace.TraceInformation("This is an information message");
        Trace.TraceWarning("This is a warning message");
        Trace.TraceError("This is an error message");

        Console.WriteLine("\n--- CONDITIONAL TRACE ---");
        Debug.WriteLine("This only appears in Debug configuration");

        Console.WriteLine("\n--- PERFORMANCE MONITORING ---");
        MeasurePerformance();

        Console.WriteLine("\n--- INDENTATION ---");
        Trace.Indent();
        Trace.WriteLine("Indented message 1");
        Trace.WriteLine("Indented message 2");
        Trace.Unindent();
        Trace.WriteLine("Back to normal indentation");

        Console.WriteLine("\n--- ASSERTIONS ---");
        TestAssertions();

        Console.WriteLine("\n--- FILTERING AND LEVELS ---");
        DemonstrateFiltering();

        Trace.Flush();
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void SetupTraceListeners()
    {
        // Console trace listener
        ConsoleTraceListener consoleListener = new ConsoleTraceListener();
        Trace.Listeners.Add(consoleListener);

        // Text writer trace listener (to file)
        string logFilePath = "trace_log.txt";
        TextWriterTraceListener fileListener = new TextWriterTraceListener(logFilePath);
        Trace.Listeners.Add(fileListener);

        Console.WriteLine($"Trace listeners configured:");
        Console.WriteLine($"  - Console output");
        Console.WriteLine($"  - File output: {logFilePath}\n");
    }

    static void MeasurePerformance()
    {
        Trace.WriteLine("Starting performance measurement");
        
        var stopwatch = Stopwatch.StartNew();
        
        // Simulate work
        for (int i = 0; i < 1000000; i++)
        {
            Math.Sqrt(i);
        }
        
        stopwatch.Stop();
        Trace.TraceInformation($"Operation took {stopwatch.ElapsedMilliseconds}ms");
    }

    static void TestAssertions()
    {
        int value = 42;
        
        // Debug assert (only in Debug build)
        Debug.Assert(value > 0, "Value must be positive");
        Debug.Assert(value < 100, "Value must be less than 100");
        
        Trace.WriteLine("Assertions completed");
    }

    static void DemonstrateFiltering()
    {
        // Set trace level
        TraceSource traceSource = new TraceSource("MyApplication");
        traceSource.Switch = new SourceSwitch("mySwitch", "Verbose");

        TraceListener listener = new ConsoleTraceListener();
        listener.Filter = new EventTypeFilter(SourceLevels.Warning);
        traceSource.Listeners.Add(listener);

        Trace.WriteLine("Different trace levels available:");
        Trace.WriteLine("  - Off (0)");
        Trace.WriteLine("  - Critical (1)");
        Trace.WriteLine("  - Error (2)");
        Trace.WriteLine("  - Warning (4)");
        Trace.WriteLine("  - Information (8)");
        Trace.WriteLine("  - Verbose (16)");
        Trace.WriteLine("  - All (31)");
    }
}