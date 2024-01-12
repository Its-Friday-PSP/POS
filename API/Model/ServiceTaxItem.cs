namespace API.Model
{
    public class ServiceTaxItem
    {
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        public Guid TaxId { get; set; }
        public Tax Tax { get; set; }
    }
}
