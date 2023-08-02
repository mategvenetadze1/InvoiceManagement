using InvoiceManagement.Domain.Common;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class CreateInvoiceCommand : IRequest<Unit>
{
    public CreateInvoiceCommand()
    {
        
    }

    public CreateInvoiceCommand(DateTime invoiceDate, InvoiceStatus status, double amount)
    {
        InvoiceDate = invoiceDate;
        Status = status;
        Amount = amount;
    }

    public DateTime InvoiceDate { get; set; }
    public InvoiceStatus Status { get; set; }
    public double Amount { get; set; }
}
