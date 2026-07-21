// Program 29: Input Sanitization and XSS Prevention
// Demonstrates security practices for handling user input

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

class Program29_InputSanitizationXSSPrevention
{
    static void Main()
    {
        Console.WriteLine("=== INPUT SANITIZATION AND XSS PREVENTION ===\n");

        // Test inputs
        string[] testInputs = new string[]
        {
            "Hello World",
            "<script>alert('XSS')</script>",
            "<img src=x onerror='alert(1)'>",
            "Test&Email<tag>",
            "'; DROP TABLE users; --",
            "<iframe src='http://malicious.com'></iframe>",
            "Normal text with \"quotes\" and 'apostrophes'",
            "<b>Bold</b> and <i>italic</i>"
        };

        Console.WriteLine("--- HTML ESCAPING ---");
        DemonstrateHtmlEscaping(testInputs);

        Console.WriteLine("\n--- REMOVING HTML TAGS ---");
        DemonstrateRemovingHtmlTags(testInputs);

        Console.WriteLine("\n--- EMAIL VALIDATION ---");
        DemonstrateEmailValidation();

        Console.WriteLine("\n--- INPUT VALIDATION ---");
        DemonstrateInputValidation();

        Console.WriteLine("\n--- SQL INJECTION PREVENTION ---");
        DemonstrateSQLInjectionPrevention();

        Console.WriteLine("\n--- SECURITY BEST PRACTICES ---");
        DisplaySecurityBestPractices();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DemonstrateHtmlEscaping(string[] inputs)
    {
        Console.WriteLine("HTML Escaping (Safe for display):");
        foreach (var input in inputs)
        {
            string escaped = HttpUtility.HtmlEncode(input);
            Console.WriteLine($"  Input:   {input}");
            Console.WriteLine($"  Escaped: {escaped}\n");
        }
    }

    static void DemonstrateRemovingHtmlTags(string[] inputs)
    {
        Console.WriteLine("Removing HTML Tags:");
        foreach (var input in inputs)
        {
            string cleaned = RemoveHtmlTags(input);
            Console.WriteLine($"  Input:   {input}");
            Console.WriteLine($"  Cleaned: {cleaned}\n");
        }
    }

    static string RemoveHtmlTags(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Remove all HTML tags
        string result = Regex.Replace(input, "<[^>]*>", "");
        return result;
    }

    static void DemonstrateEmailValidation()
    {
        string[] emails = new string[]
        {
            "valid@example.com",
            "invalid.email",
            "user+tag@domain.co.uk",
            "<script>@example.com",
            "test@example",
            "user@domain.com"
        };

        Console.WriteLine("Email Validation:");
        foreach (var email in emails)
        {
            bool isValid = IsValidEmail(email);
            Console.WriteLine($"  {email}: {(isValid ? "✓ Valid" : "✗ Invalid")}");
        }
    }

    static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Simple email validation using regex
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
        catch
        {
            return false;
        }
    }

    static void DemonstrateInputValidation()
    {
        string[] inputs = new string[]
        {
            "12345",
            "abc123",
            "-100",
            "999999999999999999999999",
            "0",
            "invalid"
        };

        Console.WriteLine("Input Validation (Numeric):");
        foreach (var input in inputs)
        {
            bool isValidInt = int.TryParse(input, out int value);
            Console.WriteLine($"  {input}: {(isValidInt ? $"✓ Valid (value: {value})" : "✗ Invalid")}");
        }
    }

    static void DemonstrateSQLInjectionPrevention()
    {
        Console.WriteLine("SQL Injection Prevention:");
        Console.WriteLine("  ❌ UNSAFE: SELECT * FROM users WHERE name = '" + GetUserInput() + "'");
        Console.WriteLine("  ✓ SAFE: Use parameterized queries:");
        Console.WriteLine("    SqlCommand cmd = new SqlCommand(\"SELECT * FROM users WHERE name = @name\", conn);");
        Console.WriteLine("    cmd.Parameters.AddWithValue(\"@name\", userInput);");
        Console.WriteLine("\nParameterized queries automatically escape special characters.");
    }

    static string GetUserInput()
    {
        return "'; DROP TABLE users; --";
    }

    static void DisplaySecurityBestPractices()
    {
        Console.WriteLine("Security Best Practices:");
        Console.WriteLine("1. Always validate input on the server side");
        Console.WriteLine("2. Use parameterized queries for database operations");
        Console.WriteLine("3. Escape output based on context (HTML, JavaScript, URL)");
        Console.WriteLine("4. Implement Content Security Policy (CSP)");
        Console.WriteLine("5. Use HTTPS for all sensitive data transmission");
        Console.WriteLine("6. Sanitize user-generated content before display");
        Console.WriteLine("7. Use security headers (X-Frame-Options, X-Content-Type-Options)");
        Console.WriteLine("8. Keep frameworks and libraries updated");
        Console.WriteLine("9. Never trust user input");
        Console.WriteLine("10. Use allowlists instead of blocklists for validation");
    }
}