using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Entities;
using VF.Core.Interfaces.Repositories;

namespace VF.Infrastructure.Persistence.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    // public async Task<User?> ObterAsync(int codUser)
    // {
    //     const string sql = @"
    //         SELECT 
    //             Id, 
    //             CodUser, 
    //             Nome, 
    //             Email
    //         FROM 
    //             [User]
    //         WHERE 
    //             CodUser = @codUser";

    //     using var connection = _dbContext.Database.GetDbConnection();
        
    //     return await connection.QueryFirstOrDefaultAsync<User>(sql, new { codUser });
    // }
}
