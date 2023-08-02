using InvoiceManagement.Application.Contracts.Persistance;
using InvoiceManagement.Persistence.DBContexts;
using InvoiceManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InvoiceManagementDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("InvoiceManagementConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<DbContext, InvoiceManagementDbContext>();

        return services;
    }
}
