using VF.Application.Mappings;
using VF.Application.Services;
using VF.Core.Interfaces.Repositories;
using VF.Core.Interfaces.Services;
using VF.Infrastructure.Configurations;
using VF.Infrastructure.Persistence;
using VF.Infrastructure.Persistence.Repositories;

namespace VF.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();
        
        services.Configure<CredentialsEmailConfiguration>(configuration.GetSection("CredentialsEmail"));

        services.AddAutoMapper
        (
            typeof(AccountMappingProfile),
            typeof(FinancialInstitutionMappingProfile),
            typeof(CreditCardMappingProfile)
        );

        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ISmsService, SmsService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPendingUserService, PendingUserService>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IFinancialInstitutionRepository, FinancialInstitutionRepository>();
        services.AddScoped<IFinancialInstitutionService, FinancialInstitutionService>();
        services.AddScoped<ICreditCardRepository, CreditCardRepository>();
        services.AddScoped<ICreditCardSevice, CreditCardService>();
    }
}
