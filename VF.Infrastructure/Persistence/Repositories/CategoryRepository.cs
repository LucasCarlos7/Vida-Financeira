using Dapper;
using Microsoft.EntityFrameworkCore;
using VF.Core.Enums;
using VF.Core.Interfaces.Repositories;
using VF.Core.Models;
using VF.Core.ViewModels;

namespace VF.Infrastructure.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task RegisterCategoryAsync(CategoryModel category)
    {
        string sql =
            @"INSERT INTO Categories
                (Name, Color, TransactionType, CreatedAt, UpdatedAt)
            VALUES
                (@Name, @Color, @TransactionType, @CreatedAt, @UpdatedAt);";

        var parameter = new
        {
            Name = category.Name,
            Color = category.Color,
            TransactionType = category.TransactionType,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };

        await _dbContext.Database.GetDbConnection()
            .ExecuteAsync(sql, parameter);
    }

    public async Task RegisterSubcategoryAsync(SubcategoryModel subcategory)
    {
        string sql =
            @"INSERT INTO Subcategories
                (Name, CreatedAt, UpdatedAt,CategoryId)
            VALUES
                (@Name, @CreatedAt, @UpdatedAt, @CategoryId)";

        var parameter = new
        {
            Name = subcategory.Name,
            CreatedAt = subcategory.CreatedAt,
            UpdatedAt = subcategory.UpdatedAt,
            CategoryId = subcategory.CategoryId
        };

        await _dbContext.Database.GetDbConnection()
            .ExecuteAsync(sql, parameter);
    }

    public async Task<List<CategoryWithSubcategoriesViewModel>> GetCategoriesAsync(int transactionType)
    {
        string query =
            @"SELECT
                Id AS IdCategory,
                Name,
                Color,
                TransactionType
            FROM 
                Categories 
            WHERE TransactionType = @transactionType";

        return (await _dbContext.Database.GetDbConnection()
            .QueryAsync<CategoryWithSubcategoriesViewModel>
            (query, new { transactionType })).ToList();
    }

    public async Task<List<SubcategoryViewModel>> GetSubcategoriesAsync(List<int> categoryIds)
    {
        string query =
            @"SELECT
                Id,
                Name,
                CategoryId
            FROM 
                Subcategories 
            WHERE CategoryId IN @categoryIds"; ;

        return (await _dbContext.Database.GetDbConnection()
            .QueryAsync<SubcategoryViewModel>
            (query, new { categoryIds })).ToList();
    }

    public async Task RemoveAsync(int id)
    {
        string sql =
            @"DELETE FROM 
                Categories
            WHERE
                Id = @id";
        await _dbContext.Database.GetDbConnection()
            .ExecuteAsync(sql, new { id });
    }

}
