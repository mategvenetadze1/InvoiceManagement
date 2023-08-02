using AutoMapper;
using InvoiceManagement.Application.Contracts.Persistance;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Queries;

public class GetInvoiceHandler : IRequestHandler<GetInvoiceQuery, InvoiceDto>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;

    public GetInvoiceHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<InvoiceDto> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetAsync(request.ID);
        var result = _mapper.Map<InvoiceDto>(invoice);
        return result;
    }
}
