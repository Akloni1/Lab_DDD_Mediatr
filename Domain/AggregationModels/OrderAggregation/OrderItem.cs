using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;

namespace DomainDrivenDesign.Domain.AggregationModels.OrderAggregation
{
    public class OrderItem //AggregationRoot
    {
        public OrderItem()
        {
        }

        public OrderItem(Dish dish, int quantity)
        {
            Dish = dish;
            Quantity = quantity;
        }
        public long Id { get; }
        public virtual Dish Dish { get; }
        public long DishId { get; }
        public virtual Order Order { get; }
        public long OrderId { get; }
        public int Quantity { get; }
    }
}
