using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using DomainDrivenDesign.Repository;
using DomainDrivenDesign.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Application.Mediatr
{
    public class GetDishsQuery : IRequest<ICollection<DishViewModel>>
    {
    }

    public class GetDishsQueryHandler : IRequestHandler<GetDishsQuery, ICollection<DishViewModel>>
    {
        private readonly IRepository<Dish> _repository;

        public GetDishsQueryHandler(IRepository<Dish> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DishViewModel>> Handle(GetDishsQuery request, CancellationToken cancellationToken)
        {
            var models = await _repository.GetAll().ToListAsync(cancellationToken);
            List<DishViewModel> res = new List<DishViewModel>();
            foreach (var item in models)
            {
                res.Add(new DishViewModel { Id = item.Id, Name = item.Name, Price = item.Price });
            }
            return res;
        }
    }
}
