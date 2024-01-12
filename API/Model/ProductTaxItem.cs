namespace API.Model
{
    public class ProductTaxItem
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}
