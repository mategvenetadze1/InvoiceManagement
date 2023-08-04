using InvoiceManagement.Application.Contracts.Persistance;
using InvoiceManagement.Application.Exceptions;
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

    public override Task UpdateAsync(Invoice entity)
    {
        var invoice = _invoices.Find(entity.ID) ?? 
            throw new NotFoundException("Invoice", entity.ID);

        invoice.Status = entity.Status;
        invoice.Amount = entity.Amount;

        return base.UpdateAsync(invoice);
    }
}
