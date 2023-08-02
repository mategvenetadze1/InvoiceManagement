using AutoMapper;
using InvoiceManagement.Application.Contracts.Persistance;
using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Queries;

public class GetInvoicesHandler : IRequestHandler<GetInvoicesQuery, List<InvoiceDto>>
{
    private readonly IMapper _mapper;
    private readonly IInvoiceRepository _invoiceRepository;

    public GetInvoicesHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
    {
        _mapper = mapper;
        _invoiceRepository = invoiceRepository;
    }

    public async Task<List<InvoiceDto>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepository.GetAsync();
        var result = _mapper.Map<List<InvoiceDto>>(invoices);
        return result;
    }
}
