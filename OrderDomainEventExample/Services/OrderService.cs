using OrderDomainEventExample.OrderDomain;
using OrderDomainEventExample.Utils.EventDispatcher;

namespace OrderDomainEventExample.Services;

public class OrderService
{
    private readonly IDomainEventDispatcher _eventDispatcher;

    public OrderService(IDomainEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }

    public async Task CreateOrderAsync(Guid customerId, List<OrderItem> items)
    {
        var order = new Order(customerId, items);

        // Імітація збереження замовлення до БД
        Console.WriteLine($"Order {order.Id} created for Customer {customerId}.");

        // Обробка подій
        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventDispatcher.DispatchAsync(domainEvent);
        }

        order.ClearDomainEvents();
    }
}

