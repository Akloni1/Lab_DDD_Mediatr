using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class DeleteDishComand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteDishComandHandler : IRequestHandler<DeleteDishComand>
    {
        private readonly IRepository<Dish> _repository;

        public DeleteDishComandHandler(IRepository<Dish> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteDishComand request, CancellationToken cancellationToken)
        {
            var delModel = await _repository
                .GetAll()
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new Exception("Блюдо не найдено");

            await _repository.Delete(delModel, cancellationToken);
        }
    }
}
