using API.Model;

namespace API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer);
        public Customer? GetCustomer(Guid customerId);
        public Customer? GetCustomer(string email);
        public List<Customer> GetCustomers();
        public Customer UpdateCustomer(Guid customerId, Customer customer);
        public Customer DeleteCustomer(Guid customerId);
    }
}
