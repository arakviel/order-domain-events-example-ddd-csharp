using OrderDomainEventExample.OrderDomain.Handlers;

public class InventoryService : IInventoryService
{
    private readonly Dictionary<Guid, int> _productStock = new();

    // Ініціалізація складу з початковими даними
    public Task InitializeStock(Dictionary<Guid, int> initialStock)
    {
        foreach (var item in initialStock)
        {
            _productStock[item.Key] = item.Value;
            Console.WriteLine($"Initialized stock for ProductId {item.Key} with quantity {item.Value}");
        }

        return Task.CompletedTask;
    }

    public Task DecreaseStockAsync(Guid productId, int quantity)
    {
        if (!_productStock.ContainsKey(productId))
            throw new InvalidOperationException("Product does not exist in inventory.");

        if (_productStock[productId] < quantity)
            throw new InvalidOperationException("Not enough stock available.");

        _productStock[productId] -= quantity;
        Console.WriteLine($"Decreased stock for ProductId {productId} by {quantity}. Remaining: {_productStock[productId]}");
        return Task.CompletedTask;
    }

    public Task IncreaseStockAsync(Guid productId, int quantity)
    {
        if (!_productStock.ContainsKey(productId))
            _productStock[productId] = 0;

        _productStock[productId] += quantity;
        Console.WriteLine($"Increased stock for ProductId {productId} by {quantity}. Total: {_productStock[productId]}");
        return Task.CompletedTask;
    }

    public Task<int> GetAvailableStockAsync(Guid productId)
    {
        if (!_productStock.ContainsKey(productId))
            return Task.FromResult(0);

        return Task.FromResult(_productStock[productId]);
    }
}