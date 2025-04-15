using VF.Infrastructure.Persistence;

namespace VF.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }
}
