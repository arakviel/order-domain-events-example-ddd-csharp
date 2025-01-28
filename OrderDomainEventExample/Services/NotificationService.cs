namespace OrderDomainEventExample.OrderDomain.Handlers;

public class NotificationService : INotificationService
{
    public Task SendNotificationAsync(Guid orderId, string message)
    {
        Console.WriteLine($"Notification sent for OrderId {orderId}: {message}");
        return Task.CompletedTask;
    }

    public Task NotifyCustomerAsync(Guid customerId, string message)
    {
        Console.WriteLine($"Notification sent to CustomerId {customerId}: {message}");
        return Task.CompletedTask;
    }
}
