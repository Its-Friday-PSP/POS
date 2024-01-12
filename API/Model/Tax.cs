using API.DTOs;
using API.Enumerators;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Model
{
    public class Tax
    {
        public Guid Id { get; set; }
        public TaxType Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Percentage { get; set; }
        public long? Price { get; set; }
        public List<ProductTaxItem>? ProductTaxes { get; set; }
        public List<ServiceTaxItem>? ServiceTaxes { get; set; }
    }
}
