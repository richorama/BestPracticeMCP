using ColorsCommonMCP;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

namespace ColorsMCP
{
    public class Program
    {
   
        static async Task Main(string[] args)
        {
            var builder = Host.CreateEmptyApplicationBuilder(settings: null);
            builder.Services
                .AddMcpServer()
                .WithStdioServerTransport()
                .WithTools<ColorsTools>();

            builder.Services.AddSingleton<ColorsService>();
            builder.Services.AddSingleton<BestPracticesService>();

            var app = builder.Build();

            app.Services.GetRequiredService<ColorsService>();

            await app.RunAsync();

        }
    }
}
