namespace InvoiceManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key) : base($"{name} of ID ({key}) was not found")
    {

    }
}
