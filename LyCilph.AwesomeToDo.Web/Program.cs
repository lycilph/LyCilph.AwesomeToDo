using FastEndpoints;
using FastEndpoints.Swagger;
using LyCilph.AwesomeToDo.Infrastructure;
using LyCilph.AwesomeToDo.Infrastructure.Data;
using Serilog;

namespace LyCilph.AwesomeToDo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var logger = Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        logger.Information("Starting web host");

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
            .AddFastEndpoints()
            .SwaggerDocument(); //define a swagger document
        builder.Services.AddInfrastructureServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.EnableTryItOutByDefault(); });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseFastEndpoints();

        SeedDatabase(app);

        app.Run();
    }

    public static void SeedDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                SeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
            }
        }
    }
}
