using API.DTOs;

namespace API.Responses.Customer
{
    public class CreateCustomerResponse
    {
        public CustomerDTO Customer { get; set; }

        public CreateCustomerResponse(CustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
