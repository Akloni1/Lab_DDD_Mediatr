using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;

namespace DomainDrivenDesign.ViewModels
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public DishViewModel Dish { get; set; }
        public int Quantity { get; set; }
    }
}
