using AutoMapper;
using InvoiceManagement.Application.Contracts.Persistance;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;

    public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Domain.Entities.Invoice>(request);
        await _invoiceRepository.UpdateAsync(invoice);
        return Unit.Value;
    }
}