namespace OrderDomainEventExample.Services;

public interface ITelegramService
{
    Task SendMessageAsync(Guid customerId, string subject, string message);
}