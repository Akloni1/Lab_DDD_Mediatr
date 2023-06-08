using DomainDrivenDesign.Domain.AggregationModels.DishAggregation;
using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Domain.AggregationModels.OrderAggregation
{
    public class Order //AggregationRoot
    {
        public Order()
        {
        }

        public Order(Table table, IReadOnlyList<OrderItem> items, decimal totalPrice)
        {
            Table = table;
            Items = items;
            TotalPrice = totalPrice;
        }
        public long Id { get; }
        public virtual Table Table { get; }
        public long TableId { get; }
        public virtual IReadOnlyList<OrderItem> Items { get; }
        public decimal TotalPrice { get; }

    }
}
