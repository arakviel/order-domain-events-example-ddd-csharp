using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.EventHandler;

namespace OrderDomainEventExample.OrderDomain.Handlers;

public class UpdateInventoryAfterItemAddedHandler : IDomainEventHandler<OrderItemAddedEvent>
{
    private readonly IInventoryService _inventoryService;

    public UpdateInventoryAfterItemAddedHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public async Task HandleAsync(OrderItemAddedEvent domainEvent)
    {
        await _inventoryService.DecreaseStockAsync(domainEvent.OrderItem.ProductId, domainEvent.OrderItem.Quantity);
        Console.WriteLine($"Inventory updated: decreased stock for ProductId {domainEvent.OrderItem.ProductId} by {domainEvent.OrderItem.Quantity}.");
    }
}
