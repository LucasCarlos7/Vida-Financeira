using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VF.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        var configuration = new ConfigurationBuilder()
            .SetBasePath("C:\\WorkSpace\\Projetos\\Vida Financeira\\VF.API")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("TestConnectionString");
        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options, configuration);
    }
}
