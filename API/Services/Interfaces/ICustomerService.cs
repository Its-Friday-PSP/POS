using API.Model;

namespace API.Services.Interfaces
{
    public interface ICustomerService
    {
        public Customer CreateCustomer(Customer customer);
        public Customer GetCustomer(Guid customerId);
        public Customer UpdateCustomer(Guid customerId, Customer customer);
        public Customer DeleteCustomer(Guid customerId);
    }
}
