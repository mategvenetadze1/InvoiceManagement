using InvoiceManagement.Domain.Common;

namespace InvoiceManagement.Domain.Entities;

public class Invoice : BaseEntity
{
    public DateTime InvoiceDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public double Amount { get; set; }
}
