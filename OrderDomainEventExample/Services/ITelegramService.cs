namespace OrderDomainEventExample.Services;

public interface ITelegramService
{
    Task SendEmailAsync(Guid customerId, string subject, string message);
}