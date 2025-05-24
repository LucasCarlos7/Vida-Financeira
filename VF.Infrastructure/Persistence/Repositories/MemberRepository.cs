using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Infrastructure.Persistence.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _dbContext;
    public async Task RegisterAsync(MemberModel member)
    {
        string sql =
            @"INSERT INTO Members
                (FullName, DateBirth, Relationship)
            VALUES
                (@FullName, @DateBirth, @Relationship)";

        var parameter = new
        {
            FullName = member.FullName,
            DateBirth = member.DateBirth,
            Relationship = member.Relationship
        };

        await _dbContext.Database.GetDbConnection()
            .ExecuteAsync(sql, parameter);
    }

    public async Task<List<MembersViewModel>> GetAllAsync()
    {
        string query =
            @"SELECT
                Id,
                FullName, 
                DateBirth, 
                Relationship
            FROM
                Members";

        return (await _dbContext.Database.GetDbConnection()
            .QueryAsync<MembersViewModel>(query)).ToList();
    }

}
