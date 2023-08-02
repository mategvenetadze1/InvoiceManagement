using Microsoft.AspNetCore.Mvc;
using MediatR;
using InvoiceManagement.Application.Features.Invoice.Queries;
using InvoiceManagement.Application.Features.Invoice.Commands;

namespace InvoiceManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<InvoiceDto>> Get()
    {
        return await _mediator.Send(new GetInvoicesQuery());
    }

    [HttpGet("{id}")]
    public async Task<InvoiceDto> Get(int id)
    {
        return await _mediator.Send(new GetInvoiceQuery(id));
    }

    [HttpPost]
    public async Task Post([FromBody] CreateInvoiceCommand invoice)
    {
        await _mediator.Send(invoice);
    }

    [HttpPut]
    public async Task Put([FromBody] UpdateInvoiceCommand invoice)
    {
        await _mediator.Send(invoice);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _mediator.Send(new DeleteInvoiceCommand(id));
    }
}
