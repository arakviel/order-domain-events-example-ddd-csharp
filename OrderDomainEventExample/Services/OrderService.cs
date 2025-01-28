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
        await DispatchDomainEventsAsync(order);
    }

    public async Task AddItemToOrderAsync(Order order, OrderItem item)
    {
        order.AddItem(item);

        // Імітація оновлення замовлення в БД
        Console.WriteLine($"Item {item.ProductId} added to Order {order.Id}.");

        // Обробка подій
        await DispatchDomainEventsAsync(order);
    }

    public async Task RemoveItemFromOrderAsync(Order order, Guid productId)
    {
        order.RemoveItem(productId);

        // Імітація оновлення замовлення в БД
        Console.WriteLine($"Item {productId} removed from Order {order.Id}.");

        // Обробка подій
        await DispatchDomainEventsAsync(order);
    }

    public async Task UpdateItemQuantityAsync(Order order, Guid productId, int newQuantity)
    {
        order.UpdateItemQuantity(productId, newQuantity);

        // Імітація оновлення замовлення в БД
        Console.WriteLine($"Item {productId} quantity updated in Order {order.Id}.");

        // Обробка подій
        await DispatchDomainEventsAsync(order);
    }

    public async Task ChangeOrderStatusAsync(Order order, string newStatus)
    {
        order.ChangeStatus(newStatus);

        // Імітація оновлення замовлення в БД
        Console.WriteLine($"Order {order.Id} status changed to {newStatus}.");

        // Обробка подій
        await DispatchDomainEventsAsync(order);
    }

    private async Task DispatchDomainEventsAsync(Order order)
    {
        foreach (var domainEvent in order.DomainEvents)
        {
            await _eventDispatcher.DispatchAsync(domainEvent);
        }

        order.ClearDomainEvents();
    }
}
