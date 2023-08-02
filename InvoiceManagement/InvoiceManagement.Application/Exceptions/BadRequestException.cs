namespace InvoiceManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public List<string> ValidationErrors { get; set; } = new();

    public BadRequestException(string message) : base(message)
    {
        ValidationErrors.Add(message);
    }

    public BadRequestException(List<string> validationErrors)
    {
        ValidationErrors = validationErrors;
    }
}
