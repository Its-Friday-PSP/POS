namespace API.Model
{
    public class ServiceOrder : Order
    {
        public List<Service>? Services { get; set; }

        public ServiceOrder(Guid customerId, IEnumerable<Service>? services) : base(customerId)
        {
            Services = services.ToList();
        }

        public ServiceOrder(Guid customerId) : base(customerId)
        {
        }
        public ServiceOrder(IEnumerable<Service>? services) : base()
        {
            Services = services.ToList();
        }
    }
}