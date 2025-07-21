using ModelContextProtocol.Server;
using System.ComponentModel;

namespace BestPracticesCommonMCP;

[McpServerToolType]
public sealed class BestPracticesTools
{
    private readonly BestPracticesService bestPracticesService;

    public BestPracticesTools(BestPracticesService bestPracticesService)
    {
        this.bestPracticesService = bestPracticesService;
    }

    [McpServerTool, Description(BestPracticesInfo.GetBestPracticesToolDescription)]
    public async Task<string?> GetBestPractices([Description(BestPracticesInfo.GetBestPracticesParamFileExtensionDescription)] string fileExtension)
    {
        return await bestPracticesService.GetBestPractices(fileExtension);
    }

    [McpServerTool, Description(BestPracticesInfo.GetSupportedExtensionsToolDescription)]
    public async Task<string> GetSupportedExtensions()
    {
        return await bestPracticesService.GetSupportedExtensions();
    }

    [McpServerTool, Description(BestPracticesInfo.GetAllBestPracticesToolDescription)]
    public async Task<string> GetAllBestPractices()
    {
        return await bestPracticesService.GetAllBestPractices();
    }
}
