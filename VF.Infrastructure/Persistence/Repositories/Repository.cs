using Microsoft.EntityFrameworkCore;
using VF.Core.Interfaces.Repositories;

namespace VF.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetValueByIdAsync(int id)
    {
        return await _appDbContext.Set<T>()
            .FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
    }

    public async Task CreateAsync(T entity)
    {
        _appDbContext.Set<T>().Add(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }
}