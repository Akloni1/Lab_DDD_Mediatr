namespace DomainDrivenDesign.ViewModels
{
    public class CreateOrderViewModel
    {
        public long Id { get; set; }
        public long TableId { get; set; }
        public IReadOnlyList<DishViewModelForCreate> Items { get; set; }
        public decimal? TotalPrice { get; set; }
    }


    public class DishViewModelForCreate
    {
        public long DishId { get; set; }
        public int Quantity { get; set; }
    }
}
