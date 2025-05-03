using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;

namespace VF.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _appDbContext;

    public AccountRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task RegisterAsync(AccountModel accountModel)
    {
        string script = 
            @"INSERT INTO Accounts
                (AccountDescription, AccountName, AccountType, Balance, FinancialInstitutionId,
                IsMainAccount, RegistrationType, IsFiled, CreatedAt, UpdatedAt, UserId)
            VALUES
                (@AccountDescription, @AccountName, @AccountType, @Balance, @FinancialInstitutionId,
                @IsMainAccount, @RegistrationType, @IsFiled, @CreatedAt, @UpdatedAt, @UserId)";

            var parameter = new
            {
                AccountDescription = accountModel.AccountDescription,
                AccountName = accountModel.AccountName,
                AccountType = accountModel.AccountType,
                Balance = accountModel.Balance,
                FinancialInstitutionId = accountModel.FinancialInstitutionId,
                IsMainAccount = accountModel.IsMainAccount,
                RegistrationType = accountModel.RegistrationType,
                IsFiled = accountModel.IsFiled,
                CreatedAt = accountModel.CreatedAt,
                UpdatedAt = accountModel.UpdatedAt,
                UserId = accountModel.UserId
            };

            await _appDbContext.Database.GetDbConnection()
                .ExecuteAsync(script, parameter);
    }

}
