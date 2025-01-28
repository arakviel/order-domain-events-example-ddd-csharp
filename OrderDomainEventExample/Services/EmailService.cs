namespace OrderDomainEventExample.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(Guid customerId, string subject, string message)
    {
        // Логіка для відправки email (наприклад, через SMTP або сторонній API)
        Console.WriteLine($"Email sent to CustomerId: {customerId}, Subject: {subject}, Message: {message}");
        return Task.CompletedTask;
    }
}
