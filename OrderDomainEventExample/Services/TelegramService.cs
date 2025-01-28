namespace OrderDomainEventExample.Services;
public class TelegramService : ITelegramService
{
    public Task SendMessageAsync(Guid customerId, string subject, string message)
    {
        // Логіка для відправки email (наприклад, через SMTP або сторонній API)
        Console.WriteLine($"Telegram message sent to CustomerId: {customerId}, Subject: {subject}, Message: {message}");
        return Task.CompletedTask;
    }
}