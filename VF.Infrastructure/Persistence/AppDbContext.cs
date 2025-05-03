using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VF.Core.Entities;

namespace VF.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public AppDbContext
    (
        DbContextOptions<AppDbContext> options, 
        IConfiguration configuration
    ) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
    
    // public DbSet<ManualFinancialInstitution> ManualFinancialInstitutions { get; set; }
    // public DbSet<AutomaticFinancialInstitution> AutomaticFinancialInstitutions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var connectionString = _configuration.GetConnectionString("TestConnectionString");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Conexão com o banco de dados não está configurada corretamente.");
        }

        optionsBuilder.UseSqlServer(connectionString);
    }
}
