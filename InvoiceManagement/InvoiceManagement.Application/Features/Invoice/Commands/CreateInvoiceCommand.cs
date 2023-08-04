using InvoiceManagement.Domain.Common;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class CreateInvoiceCommand : IRequest<Unit>
{
    public CreateInvoiceCommand()
    {
        
    }

    public CreateInvoiceCommand(InvoiceStatus status, double amount)
    {
        Status = status;
        Amount = amount;
    }

    public InvoiceStatus Status { get; set; }
    public double Amount { get; set; }
}
