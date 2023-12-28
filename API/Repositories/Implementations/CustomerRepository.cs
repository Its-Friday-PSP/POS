using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var id = Guid.NewGuid();
            customer.Id = id;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Customer? GetCustomer(string email)
        {
            return _context.Customers.FirstOrDefault(customer => customer.Auth.Email.ToLower().Equals(email.ToLower()));
        }

        public Customer UpdateCustomer(Guid customerId, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
