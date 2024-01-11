namespace API.Model
{
    public class TaxItem
    {
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid? ServiceId { get; set; }
        public Service? Service { get; set; }

        public Guid TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}
