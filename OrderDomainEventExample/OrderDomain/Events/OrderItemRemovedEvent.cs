using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain.Events;

public class OrderItemRemovedEvent : IDomainEvent
{
    public Guid OrderId { get; }
    public Guid ProductId { get; }

    public DateTime OccurredOn { get; }

    public OrderItemRemovedEvent(Guid orderId, Guid productId)
    {
        OrderId = orderId;
        ProductId = productId;
        OccurredOn = DateTime.UtcNow;
    }
}