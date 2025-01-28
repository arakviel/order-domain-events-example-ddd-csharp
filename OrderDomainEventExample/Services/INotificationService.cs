namespace OrderDomainEventExample.OrderDomain.Handlers;

public interface INotificationService
{
    /// <summary>
    /// Надіслати сповіщення замовнику.
    /// </summary>
    /// <param name="orderId">Ідентифікатор замовлення.</param>
    /// <param name="message">Текст повідомлення.</param>
    /// <returns>Завдання для асинхронного виконання.</returns>
    Task SendNotificationAsync(Guid orderId, string message);

    /// <summary>
    /// Надіслати сповіщення про оновлення статусу.
    /// </summary>
    /// <param name="customerId">Ідентифікатор клієнта.</param>
    /// <param name="message">Текст повідомлення.</param>
    /// <returns>Завдання для асинхронного виконання.</returns>
    Task NotifyCustomerAsync(Guid customerId, string message);
}
