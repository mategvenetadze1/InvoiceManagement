using InvoiceManagement.Application.Features.Invoice.Queries;
using InvoiceManagement.Domain.Common;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class UpdateInvoiceCommand : IRequest<Unit>
{
    public UpdateInvoiceCommand()
    {

    }

    public UpdateInvoiceCommand(int id, InvoiceStatus status, double amount)
    {
        ID = id;
        Status = status;
        Amount = amount;
    }

    public int ID { get; set; }
    public InvoiceStatus Status { get; set; }
    public double Amount { get; set; }
}
