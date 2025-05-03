using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;

namespace VF.Infrastructure.Persistence.Repositories;

public class FinancialInstitutionRepository : IFinancialInstitutionRepository
{
    private readonly AppDbContext _appDbContext;

    public FinancialInstitutionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task RegisterAsync(FinancialInstitutionModel financialInstitutionModel)
    {
        string script =
            @"INSERT INTO FinancialInstitutions
                (Name, PhotoUrl, CreatedAt, UpdatedAt)
            VALUES
                (@Name, @PhotoUrl, @CreatedAt, @UpdatedAt)";

        var parameter = new
        {
            Name = financialInstitutionModel.Name,
            PhotoUrl = financialInstitutionModel.PhotoUrl,
            CreatedAt = financialInstitutionModel.CreatedAt,
            UpdatedAt = financialInstitutionModel.UpdatedAt,
        };

        await _appDbContext.Database.GetDbConnection()
            .ExecuteAsync(script, parameter);
    }

}
