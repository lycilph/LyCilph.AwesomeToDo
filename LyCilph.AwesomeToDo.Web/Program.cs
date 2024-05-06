using FastEndpoints;
using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using LyCilph.AwesomeToDo.UseCases.Projects.Create;
using LyCilph.AwesomeToDo.Infrastructure;
using System.Reflection;
using LyCilph.AwesomeToDo.Infrastructure.Data;

namespace LyCilph.AwesomeToDo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // FastEndpoints setup
        builder.Services.AddFastEndpoints();

        builder.Services.AddInfrastructureServices();

        ConfigureMediatR(builder.Services);

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

    public static void ConfigureMediatR(IServiceCollection services)
    {
        var assemblies = new[]
        {
            Assembly.GetAssembly(typeof(Project)), // Core project
            Assembly.GetAssembly(typeof(CreateProjectCommand)) // UseCases project
        };

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies!));

  //      var mediatRAssemblies = new[]
  //      {
  //  Assembly.GetAssembly(typeof(Project)), // Core
  //  Assembly.GetAssembly(typeof(CreateContributorCommand)), // UseCases
  //  Assembly.GetAssembly(typeof(InfrastructureServiceExtensions)) // Infrastructure
  //};

  //      builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
  //      builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
  //      builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
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
                // Log stuff here
                throw;
            }
        }
    }
}
