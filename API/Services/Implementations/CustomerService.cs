using API.Exceptions;
using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Stripe;

namespace API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDiscountRepository _discountRepository;

        public CustomerService(ICustomerRepository customerRepository, IDiscountRepository discountRepository)
        {
            _customerRepository = customerRepository;
            _discountRepository = discountRepository;
        }

        public Model.Customer CreateCustomer(Model.Customer customer, IEnumerable<string> discounts)
        {
            if (EmailAlreadyRegistered())
            {
                throw new EmailAlreadyRegisteredException("Customer with this email is already registered");
            }

            if (discounts != null)
            {
                var selectedDiscounts = _discountRepository
                    .GetDiscounts(discounts)
                    .Select(x => new CustomerDiscount() { CustomerId = customer.Id, DiscountId = x.Id })
                    .ToList();

                customer.CustomerDiscounts = selectedDiscounts;
            }
            var createdCustomer = _customerRepository.CreateCustomer(customer);
            var accOptions = new CustomerCreateOptions
            {
                //Password = "hello",
                Email = createdCustomer.Auth.Email,
                //Description = "My First Test Customer (created for API docs at https://www.stripe.com/docs/api)",
            };
            var accService = new Stripe.CustomerService();
            var stripeCustomer = accService.Create(accOptions);

            createdCustomer.StripeId = stripeCustomer.Id;
            _customerRepository.UpdateCustomer(createdCustomer.Id, createdCustomer);
            return createdCustomer;
        }

        private bool EmailAlreadyRegistered()
        {
            // kazkokia tikrinimo logika
            return false;
        }

        public Model.Customer DeleteCustomer(Guid customerId)
        {
            return _customerRepository.DeleteCustomer(customerId);
        }

        public Model.Customer GetCustomer(Guid customerId)
        {
            return _customerRepository.GetCustomer(customerId);
        }

        public List<Model.Customer> GetCustomers()
        {
           return _customerRepository.GetCustomers();
        }

        public Model.Customer UpdateCustomer(Guid customerId, Model.Customer customer)
        {
            return _customerRepository.UpdateCustomer(customerId, customer);
        }
    }
}
