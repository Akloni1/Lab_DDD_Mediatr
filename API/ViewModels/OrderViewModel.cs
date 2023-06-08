using DomainDrivenDesign.Domain.AggregationModels.OrderAggregation;

namespace DomainDrivenDesign.ViewModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public TableViewModel Table { get; set; }
        public IReadOnlyList<OrderItemViewModel> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
