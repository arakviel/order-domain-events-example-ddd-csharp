using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.EventHandler;

namespace OrderDomainEventExample.OrderDomain.Handlers;

public class NotifyCustomerOnOrderStatusChangeHandler : IDomainEventHandler<OrderStatusChangedEvent>
{
    private readonly INotificationService _notificationService;

    public NotifyCustomerOnOrderStatusChangeHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task HandleAsync(OrderStatusChangedEvent domainEvent)
    {
        var message = $"Ваше замовлення {domainEvent.OrderId} змінено зі статусу '{domainEvent.OldStatus}' на '{domainEvent.NewStatus}'.";
        await _notificationService.SendNotificationAsync(domainEvent.OrderId, message);

        Console.WriteLine($"Notification sent to customer about status change for OrderId {domainEvent.OrderId}.");
    }
}
