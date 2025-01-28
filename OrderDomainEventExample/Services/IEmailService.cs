namespace OrderDomainEventExample.Services;

public interface IEmailService
{
    Task SendEmailAsync(Guid customerId, string subject, string message);
}