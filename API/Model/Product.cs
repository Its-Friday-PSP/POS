using API.Enumerators;

namespace API.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public int AmountInStock { get; set; }
        public OriginCountry OriginCountry { get; set; }
    }
}
