using API.Enumerators;

namespace API.DTOs.Request
{
    public class TaxCreationRequestDTO
    {
        public TaxType Type { get; set; }
        public int? Percentage { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
