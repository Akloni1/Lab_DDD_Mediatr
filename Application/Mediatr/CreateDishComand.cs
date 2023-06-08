using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class CreateDishComand : IRequest
    {
        public CreateDishViewModel Dish { get; set; }
    }

    public class AddDishComandHandler : IRequestHandler<CreateDishComand>
    {
        private readonly IRepository<Dish> _repository;

        public AddDishComandHandler(IRepository<Dish> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateDishComand request, CancellationToken cancellationToken)
        {
            var ingredients = new List<Ingredient>();
            foreach (var item in request.Dish.Ingredients)
            {
                ingredients.Add(new Ingredient(item.Name, item.Price));
            }
            var model = new Dish(request.Dish.Name, request.Dish.Price, ingredients);
            await _repository.Add(model, cancellationToken);
        }
    }
}
