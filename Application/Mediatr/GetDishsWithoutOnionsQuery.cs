using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{

    public class GetDishsWithoutOnionsQuery : IRequest<ICollection<DishViewModel>>
    {
    }

    public class GetDishsWithoutOnionsQueryHandler : IRequestHandler<GetDishsWithoutOnionsQuery, ICollection<DishViewModel>>
    {
        private readonly IRepository<Dish> _repository;

        public GetDishsWithoutOnionsQueryHandler(IRepository<Dish> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Возвращаем список блюд не содержащих лук
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public async Task<ICollection<DishViewModel>> Handle(GetDishsWithoutOnionsQuery request, CancellationToken cancellationToken)
        {
            var models = await _repository.GetAll()
                .Where(x => x.Ingredients.All(a => a.Name != "Лук"))
                .ToListAsync(cancellationToken);

            List<DishViewModel> res = new List<DishViewModel>();
            foreach (var item in models)
            {
                res.Add(new DishViewModel { Id = item.Id, Name = item.Name, Price = item.Price });
            }
            return res;
        }
    }

}
