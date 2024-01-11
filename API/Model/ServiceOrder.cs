namespace API.Model
{
    public class ServiceOrder : Order
    {
        public List<Service>? Services { get; set; }

        public ServiceOrder(Guid customerId, IEnumerable<Service>? services) : base(customerId)
        {
            OrderType = Enumerators.OrderType.SERVICE;
            Services = services.ToList();
        }

        public ServiceOrder(Guid customerId) : base(customerId)
        {
            OrderType = Enumerators.OrderType.SERVICE;
        }
        public ServiceOrder(IEnumerable<Service>? services) : base()
        {
            OrderType = Enumerators.OrderType.SERVICE;
            Services = services.ToList();
        }
    }
}