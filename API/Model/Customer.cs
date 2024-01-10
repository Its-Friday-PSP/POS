namespace API.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Auth Auth { get; set; }
        public string? StripeId { get; set; }
        public List<CustomerDiscount> CustomerDiscounts { get; set; }

        public Customer()
        {

        }
    }
}
