using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;

namespace VF.Infrastructure.Persistence.Repositories;

public class CreditCardRepository : ICreditCardRepository
{
    private readonly AppDbContext _appDbContext;

    public CreditCardRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task RegisterAsync(CreditCardModel creditCard)
    {
        string script = 
            @"INSERT INTO CreditCards
                (CardName, CardFlag, DueDay, MothlyLimit, AccountId, CreatedAt, UpdatedAt)
            VALUES
                (@CardName, @CardFlag, @DueDay, @MothlyLimit, @AccountId, @CreatedAt, @UpdatedAt)";

        var parameter = new
        {
            CardName = creditCard.CardName,
            CardFlag = creditCard.CardFlag,
            DueDay = creditCard.DueDay,
            MothlyLimit = creditCard.MothlyLimit,
            AccountId = creditCard.AccountId,
            CreatedAt = creditCard.CreatedAt,
            UpdatedAt = creditCard.UpdatedAt
        };

        await _appDbContext.Database.GetDbConnection()
            .ExecuteAsync(script, parameter);
    }
}
