using API.Enumerators;
using API.Shared;

namespace API.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
        public int? AmountInStock { get; set; }
        public string? StripeId { get; set; }
        public OriginCountry OriginCountry { get; set; }
        public List<ProductTaxItem>? Taxes { get; set; }
    }
}
