using MediatR;

namespace InvoiceManagement.Application.Features.Invoice.Queries;

public record GetInvoiceQuery(int ID) : IRequest<InvoiceDto>;