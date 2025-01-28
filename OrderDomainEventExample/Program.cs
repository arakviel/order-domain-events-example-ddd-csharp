using Microsoft.Extensions.DependencyInjection;
using OrderDomainEventExample.OrderDomain;
using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.OrderDomain.Handlers;
using OrderDomainEventExample.Services;
using OrderDomainEventExample.Utils.EventDispatcher;
using OrderDomainEventExample.Utils.EventHandler;

var services = new ServiceCollection();
services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();

// Сервіси для обробки подій
services.AddSingleton<IEmailService, EmailService>();
services.AddSingleton<ITelegramService, TelegramService>();
services.AddSingleton<IInventoryService, InventoryService>();
services.AddSingleton<INotificationService, NotificationService>();

// Хендлери для подій
services.AddTransient<IDomainEventHandler<OrderCreatedEvent>, SendOrderConfirmationEmailHandler>();
services.AddTransient<IDomainEventHandler<OrderCreatedEvent>, SendOrderConfirmationTelegramHandler>();
services.AddTransient<IDomainEventHandler<OrderItemAddedEvent>, UpdateInventoryAfterItemAddedHandler>();
services.AddTransient<IDomainEventHandler<OrderItemRemovedEvent>, UpdateInventoryAfterItemRemovedHandler>();
services.AddTransient<IDomainEventHandler<OrderItemQuantityUpdatedEvent>, UpdateInventoryAfterQuantityChangeHandler>();
services.AddTransient<IDomainEventHandler<OrderStatusChangedEvent>, NotifyCustomerOnOrderStatusChangeHandler>();

var serviceProvider = services.BuildServiceProvider();

// Отримуємо необхідні сервіси
var dispatcher = serviceProvider.GetRequiredService<IDomainEventDispatcher>();
var orderService = new OrderService(dispatcher);
var inventoryService = serviceProvider.GetRequiredService<IInventoryService>();

// Ініціалізуємо склад початковими даними
var initialStock = new Dictionary<Guid, int>
{
    { Guid.NewGuid(), 100 },  // Продукт 1, кількість 100
    { Guid.NewGuid(), 50 },   // Продукт 2, кількість 50
    { Guid.NewGuid(), 200 }   // Продукт 3, кількість 200
};

await inventoryService.InitializeStock(initialStock);

// Створюємо замовлення
await orderService.CreateOrderAsync(Guid.NewGuid(), new List<OrderItem>
{
    new OrderItem(initialStock.Keys.ElementAt(0), 2, 100),  // Використовуємо перший продукт із 100 одиницями
    new OrderItem(initialStock.Keys.ElementAt(1), 1, 50)    // Використовуємо другий продукт із 50 одиницями
});

// Додаємо елемент до замовлення
var order = new Order(Guid.NewGuid(), new List<OrderItem>
{
    new OrderItem(initialStock.Keys.ElementAt(0), 2, 100)
});
await orderService.AddItemToOrderAsync(order, new OrderItem(initialStock.Keys.ElementAt(1), 3, 75));

// Оновлюємо кількість елемента в замовленні
await orderService.UpdateItemQuantityAsync(order, order.Items[0].ProductId, 5);

// Видаляємо елемент з замовлення
await orderService.RemoveItemFromOrderAsync(order, order.Items[0].ProductId);

// Змінюємо статус замовлення
await orderService.ChangeOrderStatusAsync(order, "Shipped");