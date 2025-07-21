namespace BestPracticesCommonMCP;

public class BestPracticesService
{
    private readonly string bestPracticesDirectory;
    private readonly Dictionary<string, string> supportedExtensions;

    public BestPracticesService()
    {
        // Try to find the best-practices directory relative to the assembly location
        var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var assemblyDirectory = Path.GetDirectoryName(assemblyLocation) ?? AppDomain.CurrentDomain.BaseDirectory;
        bestPracticesDirectory = Path.Combine(assemblyDirectory, "best-practices");
        
        // Define supported extensions and their display names
        supportedExtensions = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { ".cs", "C#" },
            { ".js", "JavaScript" },
            { ".py", "Python" },
            { ".json", "JSON" },
            { ".html", "HTML" }
        };
    }

    public async Task<string?> GetBestPractices(string fileExtension)
    {
        if (!fileExtension.StartsWith("."))
        {
            fileExtension = "." + fileExtension;
        }

        if (!supportedExtensions.ContainsKey(fileExtension))
        {
            return null;
        }

        var filePath = Path.Combine(bestPracticesDirectory, $"{fileExtension}.md");
        
        if (!File.Exists(filePath))
        {
            return null;
        }

        return await File.ReadAllTextAsync(filePath);
    }

    public Task<string> GetSupportedExtensions()
    {
        var result = "# Supported File Extensions\n\n";
        
        foreach (var kvp in supportedExtensions.OrderBy(x => x.Key))
        {
            result += $"- **{kvp.Key}** - {kvp.Value}\n";
        }
        
        return Task.FromResult(result);
    }

    public async Task<string> GetAllBestPractices()
    {
        var result = "# Best Practices for All Supported Languages\n\n";
        
        foreach (var kvp in supportedExtensions.OrderBy(x => x.Key))
        {
            var content = await GetBestPractices(kvp.Key);
            if (content != null)
            {
                result += content + "\n---\n\n";
            }
        }
        
        return result;
    }
}
