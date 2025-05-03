using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Entities;
using VF.Core.InputModels;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;

namespace VF.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task RegisterAsync(UserModel userModel)
        {
            string script = 
                @"INSERT INTO Users
                    (Name, Email, PasswordHash, Cpf, Phone, PhotoUrl, CreatedAt, UpdatedAt)
                VALUES
                    (@Name, @Email, @PasswordHash, @Cpf, @Phone, @PhotoUrl, @CreatedAt, @UpdatedAt)";

            var parameter = new 
            {
                Name = userModel.Name,
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash,
                Cpf = userModel.Cpf,
                Phone = userModel.Phone,
                PhotoUrl = userModel.PhotoUrl,
                CreatedAt = userModel.CreatedAt,
                UpdatedAt = userModel.UpdatedAt
            };

            await _appDbContext.Database.GetDbConnection()
                .ExecuteAsync(script, parameter);
        }
    }
}