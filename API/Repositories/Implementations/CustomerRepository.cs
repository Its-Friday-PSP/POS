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
            var customer = GetCustomer(customerId);
            _context.Customers.Remove(customer);
            _context.SaveChanges(); 
            return customer;
        }

        public Customer? GetCustomer(Guid customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public Customer? GetCustomer(string email)
        {
            return _context.Customers.FirstOrDefault(customer => customer.Auth.Email.ToLower().Equals(email.ToLower()));
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer UpdateCustomer(Guid customerId, Customer customer)
        {
            var existingCustomer = GetCustomer(customerId);
            existingCustomer.Auth = customer.Auth;
            _context.SaveChanges();
            return existingCustomer;
        }
    }
}
