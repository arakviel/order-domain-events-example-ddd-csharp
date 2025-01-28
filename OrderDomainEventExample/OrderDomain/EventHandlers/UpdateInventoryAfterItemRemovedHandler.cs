using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.EventHandler;

namespace OrderDomainEventExample.OrderDomain.Handlers;

public class UpdateInventoryAfterItemRemovedHandler : IDomainEventHandler<OrderItemRemovedEvent>
{
    private readonly IInventoryService _inventoryService;

    public UpdateInventoryAfterItemRemovedHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public async Task HandleAsync(OrderItemRemovedEvent domainEvent)
    {
        // Assuming we restore stock when an item is removed
        await _inventoryService.IncreaseStockAsync(domainEvent.ProductId, 1); // Example logic
        Console.WriteLine($"Inventory updated: increased stock for ProductId {domainEvent.ProductId} by 1.");
    }
}