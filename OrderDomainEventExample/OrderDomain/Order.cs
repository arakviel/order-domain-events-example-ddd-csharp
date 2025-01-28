using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();
    public string Status { get; private set; } = "Pending";

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public Order(Guid customerId, List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Items = items ?? throw new ArgumentNullException(nameof(items));

        AddDomainEvent(new OrderCreatedEvent(this));
    }

    public void AddItem(OrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        Items.Add(item);
        AddDomainEvent(new OrderItemAddedEvent(Id, item));
    }

    public void RemoveItem(Guid productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) throw new InvalidOperationException("Item not found in the order.");

        Items.Remove(item);
        AddDomainEvent(new OrderItemRemovedEvent(Id, productId));
    }

    public void UpdateItemQuantity(Guid productId, int newQuantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);
        if (item == null) throw new InvalidOperationException("Item not found in the order.");

        var oldQuantity = item.Quantity;
        item.UpdateQuantity(newQuantity);

        AddDomainEvent(new OrderItemQuantityUpdatedEvent(Id, productId, oldQuantity, newQuantity));
    }

    public void ChangeStatus(string newStatus)
    {
        if (string.IsNullOrWhiteSpace(newStatus)) throw new ArgumentNullException(nameof(newStatus));

        var oldStatus = Status;
        Status = newStatus;

        AddDomainEvent(new OrderStatusChangedEvent(Id, oldStatus, newStatus));
    }

    private void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
