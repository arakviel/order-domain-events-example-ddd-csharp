using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain.Events;

public class OrderStatusChangedEvent : IDomainEvent
{
    public Guid OrderId { get; }
    public string OldStatus { get; }
    public string NewStatus { get; }

    public DateTime OccurredOn { get; }

    public OrderStatusChangedEvent(Guid orderId, string oldStatus, string newStatus)
    {
        OrderId = orderId;
        OldStatus = oldStatus;
        NewStatus = newStatus;
        OccurredOn = DateTime.Now;
    }
}