using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain.Events;

public class OrderCreatedEvent : IDomainEvent
{
    public Guid OrderId { get; }
    public Guid CustomerId { get; }
    public DateTime OccurredOn { get; }

    public OrderCreatedEvent(Order order)
    {
        OrderId = order.Id;
        CustomerId = order.CustomerId;
        OccurredOn = DateTime.UtcNow;
    }
}