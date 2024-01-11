using API.DTOs;

namespace API.Model
{
    public class ServiceOrder : Order
    {
        public List<Service>? Services { get; set; }

        public ServiceOrder(Guid customerId, IEnumerable<Service>? services) : base(customerId)
        {
            OrderType = OrderTypeDTO.SERVICE;
            Services = services.ToList();
        }

        public ServiceOrder(Guid customerId) : base(customerId)
        {
            OrderType = OrderTypeDTO.SERVICE;
        }
        public ServiceOrder(IEnumerable<Service>? services) : base()
        {
            OrderType = OrderTypeDTO.SERVICE;
            Services = services.ToList();
        }
    }
}