namespace API.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? AmountInStock { get; set; }
        public HashSet<Discount> Discounts { get; set; }
    }
}
