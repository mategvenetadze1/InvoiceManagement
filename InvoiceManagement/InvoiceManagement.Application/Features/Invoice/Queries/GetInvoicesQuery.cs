using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Queries;

public record GetInvoicesQuery : IRequest<List<InvoiceDto>>;