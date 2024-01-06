namespace API.Model
{
    public class ServiceOrder : Order
    {
        public List<Service>? Services { get; set; }

        public ServiceOrder(Guid id, List<Service>? services) : base(id)
        {
            Services = services;
        }

        public ServiceOrder(Guid id) : base(id)
        {
        }
    }
}