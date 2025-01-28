using OrderDomainEventExample.OrderDomain.Events;
using OrderDomainEventExample.Services;
using OrderDomainEventExample.Utils.EventHandler;

public class SendOrderConfirmationTelegramHandler : IDomainEventHandler<OrderCreatedEvent>
{
    private readonly ITelegramService _telegramService;

    public SendOrderConfirmationTelegramHandler(ITelegramService telegramService)
    {
        this._telegramService = telegramService;
    }

    public async Task HandleAsync(OrderCreatedEvent domainEvent)
    {
        var subject = "Ваше замовлення підтверджено!";
        var message = $"Дякуємо за замовлення! Номер замовлення: {domainEvent.OrderId}.";
        await _telegramService.SendMessageAsync(domainEvent.CustomerId, subject, message);
    }
}