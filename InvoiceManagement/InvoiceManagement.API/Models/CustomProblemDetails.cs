using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.API.Models;

public class CustomProblemDetails : ProblemDetails
{
    public List<string> Errors { get; set; } = new();
}
