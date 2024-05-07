using LyCilph.AwesomeToDo.Core.Interfaces;
using LyCilph.AwesomeToDo.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace LyCilph.AwesomeToDo.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        return services;
    }
}
