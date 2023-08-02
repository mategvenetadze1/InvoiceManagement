using InvoiceManagement.Application.Contracts.Persistance;
using InvoiceManagement.Application.Exceptions;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, Unit>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetAsync(request.ID) 
            ?? throw new NotFoundException(nameof(Domain.Entities.Invoice), request.ID);

        await _invoiceRepository.DeleteAsync(invoice);
        return Unit.Value;
    }
}
