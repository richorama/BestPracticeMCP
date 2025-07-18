using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

namespace ColorsCommonMCP;

[McpServerToolType]
public sealed class ColorsTools
{
    private readonly ColorsService colorsService;
    private readonly BestPracticesService bestPracticesService;

    public ColorsTools(ColorsService colorsService, BestPracticesService bestPracticesService)
    {
        this.colorsService = colorsService;
        this.bestPracticesService = bestPracticesService;
    }

    [McpServerTool, Description(ColorsInfo.GetAllColorsToolDescription)]
    public async Task<string> GetAllColors()
    {
        var colors = await colorsService.GetColors();
        return JsonSerializer.Serialize(colors, ColorsContext.Default.ListColors);
    }

    [McpServerTool, Description(ColorsInfo.GetColorsByFamilyToolDescription)]    
    public async Task<string> GetColorByFamily([Description(ColorsInfo.GetColorsByFamilyParamFamilyDescription)] string family)
    {
        var colors = await colorsService.GetColorsByFamily(family);
        return JsonSerializer.Serialize(colors, ColorsContext.Default.ListColors);
    }


    [McpServerTool, Description(ColorsInfo.GetColorToolDescription)]
    public async Task<string> GetColor([Description(ColorsInfo.GetColorParamNameDescription)] string name)
    {
        var colors = await colorsService.GetColors(name);
        return JsonSerializer.Serialize(colors);
    }

        [McpServerTool, Description("Get best practice guidance for a specific file extension")]
    public async Task<string> GetBestPractices([Description("File extension (e.g., .cs, .js, .py)")] string fileExtension)
    {
        var guidance = await bestPracticesService.GetBestPractices(fileExtension);
        return guidance ?? $"No best practices found for file extension: {fileExtension}";
    }

    [McpServerTool, Description("Get all supported file extensions for best practices")]
    public async Task<string> GetSupportedExtensions()
    {
        return await bestPracticesService.GetSupportedExtensions();
    }

    [McpServerTool, Description("Get best practice guidance for all supported file extensions")]
    public async Task<string> GetAllBestPractices()
    {
        return await bestPracticesService.GetAllBestPractices();
    }
}
