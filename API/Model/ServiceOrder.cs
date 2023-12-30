namespace API.Model
{
    public class ServiceOrder : Order
    {
        public ServiceOrder(Guid id) : base(id)
        {
        }

        public ServiceOrder() { }
    }
}