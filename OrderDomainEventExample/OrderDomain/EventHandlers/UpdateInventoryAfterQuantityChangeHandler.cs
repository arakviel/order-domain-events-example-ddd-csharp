using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Utils.EventHandler;

namespace OrderDomainEventExample.OrderDomain.Handlers;

public class UpdateInventoryAfterQuantityChangeHandler : IDomainEventHandler<OrderItemQuantityUpdatedEvent>
{
    private readonly IInventoryService _inventoryService;

    public UpdateInventoryAfterQuantityChangeHandler(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public async Task HandleAsync(OrderItemQuantityUpdatedEvent domainEvent)
    {
        var quantityDifference = domainEvent.NewQuantity - domainEvent.OldQuantity;

        if (quantityDifference > 0)
        {
            await _inventoryService.DecreaseStockAsync(domainEvent.ProductId, quantityDifference);
            Console.WriteLine($"Inventory updated: decreased stock for ProductId {domainEvent.ProductId} by {quantityDifference}.");
        }
        else if (quantityDifference < 0)
        {
            await _inventoryService.IncreaseStockAsync(domainEvent.ProductId, Math.Abs(quantityDifference));
            Console.WriteLine($"Inventory updated: increased stock for ProductId {domainEvent.ProductId} by {Math.Abs(quantityDifference)}.");
        }
    }
}
