using API.Enumerators;
using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProductDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Price? Price { get; set; }
        public int? AmountInStock { get; set; }
        public string? StripeId { get; set; }
        public OriginCountry? OriginCountry { get; set; }
        public List<Tax> Taxes { get; set; }
    }
}
