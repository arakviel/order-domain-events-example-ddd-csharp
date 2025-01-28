
namespace OrderDomainEventExample.OrderDomain.Handlers;

public interface IInventoryService
{
    /// <summary>
    /// Зменшити кількість доступних одиниць продукту на складі.
    /// </summary>
    /// <param name="productId">Ідентифікатор продукту.</param>
    /// <param name="quantity">Кількість одиниць для зменшення.</param>
    /// <returns>Завдання для асинхронного виконання.</returns>
    Task DecreaseStockAsync(Guid productId, int quantity);

    /// <summary>
    /// Збільшити кількість доступних одиниць продукту на складі.
    /// </summary>
    /// <param name="productId">Ідентифікатор продукту.</param>
    /// <param name="quantity">Кількість одиниць для збільшення.</param>
    /// <returns>Завдання для асинхронного виконання.</returns>
    Task IncreaseStockAsync(Guid productId, int quantity);

    /// <summary>
    /// Отримати кількість доступних одиниць продукту на складі.
    /// </summary>
    /// <param name="productId">Ідентифікатор продукту.</param>
    /// <returns>Кількість доступних одиниць.</returns>
    Task<int> GetAvailableStockAsync(Guid productId);
    Task InitializeStock(Dictionary<Guid, int> initialStock);
}


