namespace API.Model
{
    public class ServiceOrder : Order
    {
        public List<Guid>? ServiceId { get; set; }

        public ServiceOrder(Guid id, List<Guid>? serviceId) : base(id)
        {
            ServiceId = serviceId;
        }

        public ServiceOrder(Guid id) : base(id)
        {
        }
    }
}