namespace DomainDrivenDesign.Domain.AggregationModels.OrderAggregation
{
    public class Table //ValueObject
    {
        public Table()
        {
        }

        public Table(int number, int capacity, bool isAvailable)
        {
            Number = number;
            Capacity = capacity;
            IsAvailable = isAvailable;
        }
        public long Id { get; }
        public int Number { get; }
        public int Capacity { get; }
        public bool IsAvailable { get; }
        public virtual IReadOnlyList<Order> Orders { get; }
    }
}
