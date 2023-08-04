using InvoiceManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManagement.Persistence.DBContexts;

public class InvoiceManagementDbContext : DbContext
{
    public InvoiceManagementDbContext(DbContextOptions<InvoiceManagementDbContext> options) : base(options)
    {

    }

    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceManagementDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<Invoice>()
                                    .Where(x => x.State == EntityState.Added);

        foreach (var entityEntry in entities)
        {
            entityEntry.Entity.InvoiceDate = DateTime.UtcNow;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
