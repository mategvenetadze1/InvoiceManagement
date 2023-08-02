using AutoMapper;
using InvoiceManagement.Application.Contracts.Persistance;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Commands;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;

    public CreateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Domain.Entities.Invoice>(request);
        await _invoiceRepository.CreateAsync(invoice);
        return Unit.Value;
    }
}
