using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain.Events;

public class OrderItemQuantityUpdatedEvent : IDomainEvent
{
    public Guid OrderId { get; }
    public Guid ProductId { get; }
    public int OldQuantity { get; }
    public int NewQuantity { get; }

    public DateTime OccurredOn { get; }

    public OrderItemQuantityUpdatedEvent(Guid orderId, Guid productId, int oldQuantity, int newQuantity)
    {
        OrderId = orderId;
        ProductId = productId;
        OldQuantity = oldQuantity;
        NewQuantity = newQuantity;
        OccurredOn = DateTime.Now;
    }
}