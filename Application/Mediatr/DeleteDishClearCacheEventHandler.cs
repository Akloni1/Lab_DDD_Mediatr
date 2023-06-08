using DomainDrivenDesign.Domain.Events;
using MediatR;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class DeleteDishClearCacheEventHandler : INotificationHandler<DeleteDishEvent>
    {
        public Task Handle(DeleteDishEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Удаляем кеш из редиса");
            return Task.CompletedTask;
        }
    }
}
