using BestPracticesCommonMCP;

var service = new BestPracticesService();

// Test getting best practices for C#
var csharpPractices = await service.GetBestPractices(".cs");
Console.WriteLine("C# Best Practices:");
Console.WriteLine(csharpPractices);
Console.WriteLine();

// Test getting supported extensions
var supportedExtensions = await service.GetSupportedExtensions();
Console.WriteLine("Supported Extensions:");
Console.WriteLine(supportedExtensions);
Console.WriteLine();

// Test getting all best practices
var allPractices = await service.GetAllBestPractices();
Console.WriteLine("All Best Practices (first 500 chars):");
Console.WriteLine(allPractices.Substring(0, Math.Min(500, allPractices.Length)));
