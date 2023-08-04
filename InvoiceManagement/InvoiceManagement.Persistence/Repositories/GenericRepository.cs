using InvoiceManagement.Application.Contracts.Persistance;
using InvoiceManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetAsync(int id)
    {
        return await _context.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(q => q.ID == id);
    }

    public virtual async Task<IReadOnlyList<T>> GetAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public virtual async Task CreateAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
