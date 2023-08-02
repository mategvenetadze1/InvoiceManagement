using InvoiceManagement.Domain.Common;

namespace InvoiceManagement.Application.Contracts.Persistance;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task<IReadOnlyList<T>> GetAsync();
    public Task<T> GetAsync(int id);
    public Task CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}
