using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.Events;

namespace OrderDomainEventExample.OrderDomain;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem> Items { get; private set; } = new();

    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public Order(Guid customerId, List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        OrderDate = DateTime.UtcNow;
        Items = items ?? throw new ArgumentNullException(nameof(items));

        // Додаємо подію в список Domain Events
        AddDomainEvent(new OrderCreatedEvent(this));
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
