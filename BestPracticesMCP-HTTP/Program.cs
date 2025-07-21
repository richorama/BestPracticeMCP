using BestPracticesCommonMCP;

namespace BestPracticesMCP_HTTP
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services
                .AddMcpServer()
                .WithHttpTransport()
                .WithTools<BestPracticesTools>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddSingleton<BestPracticesService>();
            builder.Services.AddSingleton<BestPracticesTools>();

            var app = builder.Build();

            app.UseCors();

            app.MapMcp();

            app.MapGet("/health", () => "Healthy");

            app.Run();
        }
    }
}
