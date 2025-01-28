using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain.Events;

public class OrderItemAddedEvent : IDomainEvent
{

    public Guid OrderId { get; }
    public OrderItem OrderItem { get; }

    public DateTime OccurredOn { get; }

    public OrderItemAddedEvent(Guid orderId, OrderItem orderItem)
    {
        OrderId = orderId;
        OrderItem = orderItem;
        OccurredOn = DateTime.UtcNow;
    }
}