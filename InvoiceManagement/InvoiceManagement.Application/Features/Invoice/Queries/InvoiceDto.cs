using InvoiceManagement.Domain.Common;

namespace InvoiceManagement.Application.Features.Invoice.Queries;

public class InvoiceDto
{
    public int ID { get; set; }
    public DateTime InvoiceDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public double Amount { get; set; }
}
