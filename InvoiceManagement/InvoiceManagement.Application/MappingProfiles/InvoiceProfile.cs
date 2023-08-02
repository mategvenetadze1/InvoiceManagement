using AutoMapper;
using InvoiceManagement.Application.Features.Invoice.Commands;
using InvoiceManagement.Application.Features.Invoice.Queries;
using InvoiceManagement.Domain.Entities;

namespace InvoiceManagement.Application.MappingProfiles;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>().ReverseMap();
        CreateMap<CreateInvoiceCommand, Invoice>().ReverseMap();
        CreateMap<UpdateInvoiceCommand, Invoice>().ReverseMap();
    }
}
