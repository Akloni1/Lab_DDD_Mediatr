using DomainDrivenDesign.Domain.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class DeleteDishSentNotificationEventHandler : INotificationHandler<DeleteDishEvent>
    {
        public Task Handle(DeleteDishEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"отправляем сообщение о удалении блюда всем кому нужно об этом знать");
            return Task.CompletedTask;
        }
    }
}
