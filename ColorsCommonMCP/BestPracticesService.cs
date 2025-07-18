namespace ColorsCommonMCP;

public class BestPracticesService
{
    private readonly Dictionary<string, string> bestPractices;

    public BestPracticesService()
    {
        bestPractices = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".cs", @"# Best Practices for C# (.cs)

## General Practices
- Use PascalCase for class names, method names, and property names
- Use camelCase for field names and local variables
- Use meaningful and descriptive names
- Follow the single responsibility principle
- Use async/await for asynchronous operations
- Dispose of resources properly using 'using' statements
- Use nullable reference types to avoid null reference exceptions
- Follow Microsoft's C# coding conventions

## Code Style
- Use 4 spaces for indentation
- Place opening braces on new lines
- Use explicit access modifiers
- Order using statements alphabetically
- Use var when type is obvious, explicit types otherwise

## Security Considerations
- Validate all input parameters
- Use parameterized queries for database operations
- Avoid hardcoded connection strings or secrets
- Use proper exception handling without exposing sensitive information
" },
            { ".js", @"# Best Practices for JavaScript (.js)

## General Practices
- Use const for constants and let for variables
- Avoid using var
- Use strict mode ('use strict')
- Use arrow functions for anonymous functions
- Use template literals for string interpolation
- Use async/await instead of callbacks when possible
- Use proper error handling with try/catch
- Use meaningful variable and function names

## Code Style
- Use 2 spaces for indentation
- Use semicolons consistently
- Use single quotes for strings
- Use trailing commas in objects and arrays
- Keep functions small and focused

## Security Considerations
- Validate and sanitize all user input
- Use Content Security Policy (CSP)
- Avoid eval() and similar functions
- Use HTTPS for all communications
- Don't expose sensitive data in client-side code
" },
            { ".py", @"# Best Practices for Python (.py)

## General Practices
- Follow PEP 8 style guide
- Use snake_case for variable and function names
- Use CamelCase for class names
- Use docstrings for function and class documentation
- Use type hints for better code clarity
- Use list comprehensions when appropriate
- Use context managers for resource management
- Follow the Zen of Python principles

## Code Style
- Use 4 spaces for indentation
- Keep lines under 79 characters
- Use blank lines to separate logical sections
- Import modules at the top of the file
- Use meaningful variable names

## Security Considerations
- Validate all input parameters
- Use parameterized queries for database operations
- Avoid using eval() and exec()
- Use secrets module for sensitive data
- Keep dependencies updated
" },
            { ".json", @"# Best Practices for JSON (.json)

## General Practices
- Use consistent indentation (2 or 4 spaces)
- Use double quotes for strings
- Avoid trailing commas
- Use meaningful key names
- Keep structure flat when possible
- Use arrays for ordered data
- Use objects for key-value pairs

## Code Style
- Use 2 spaces for indentation
- Use consistent formatting
- Sort keys alphabetically when appropriate
- Use proper nesting levels
- Validate JSON syntax

## Security Considerations
- Don't include sensitive information
- Validate JSON structure before parsing
- Be careful with nested objects depth
- Use schema validation when possible
" },
            { ".html", @"# Best Practices for HTML (.html)

## General Practices
- Use semantic HTML elements
- Include proper DOCTYPE declaration
- Use proper heading hierarchy (h1, h2, h3...)
- Include alt attributes for images
- Use proper form labels
- Validate HTML markup
- Use meaningful class and id names

## Code Style
- Use 2 spaces for indentation
- Use lowercase for element names
- Quote attribute values
- Close all tags properly
- Use consistent formatting

## Security Considerations
- Validate and sanitize user input
- Use Content Security Policy
- Avoid inline JavaScript
- Use HTTPS for external resources
- Escape special characters properly
" }
        };
    }

    public async Task<string?> GetBestPractices(string fileExtension)
    {
        await Task.Run(() => { });
        
        if (!fileExtension.StartsWith("."))
        {
            fileExtension = "." + fileExtension;
        }

        return bestPractices.TryGetValue(fileExtension, out var guidance) ? guidance : null;
    }

    public async Task<string> GetSupportedExtensions()
    {
        await Task.Run(() => { });
        
        var result = "# Supported File Extensions\n\n";
        
        foreach (var kvp in bestPractices.OrderBy(x => x.Key))
        {
            var language = kvp.Key switch
            {
                ".cs" => "C#",
                ".js" => "JavaScript",
                ".py" => "Python",
                ".json" => "JSON",
                ".html" => "HTML",
                _ => "Unknown"
            };
            result += $"- **{kvp.Key}** - {language}\n";
        }
        
        return result;
    }

    public async Task<string> GetAllBestPractices()
    {
        await Task.Run(() => { });
        
        var result = "# Best Practices for All Supported Languages\n\n";
        
        foreach (var kvp in bestPractices.OrderBy(x => x.Key))
        {
            result += kvp.Value + "\n---\n\n";
        }
        
        return result;
    }
}
