using InvoiceManagement.Application.Contracts.Persistance;
using InvoiceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Persistence.Repositories;

public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    protected readonly DbSet<Invoice> _invoices;

    public InvoiceRepository(DbContext dbContext) : base(dbContext)
    {
        _invoices = dbContext.Set<Invoice>();
    }
}
