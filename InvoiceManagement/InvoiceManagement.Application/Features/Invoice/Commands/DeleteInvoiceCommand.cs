using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class DeleteInvoiceCommand : IRequest<Unit>
{
    public DeleteInvoiceCommand() 
    { 

    }

    public DeleteInvoiceCommand(int id)
    {
        ID = id;
    }

    public int ID { get; set; }
}
