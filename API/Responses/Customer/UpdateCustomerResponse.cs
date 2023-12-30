using API.DTOs;

namespace API.Responses.Customer
{
    public class UpdateCustomerResponse
    {
        public CustomerDTO Customer { get; set; }

        public UpdateCustomerResponse(CustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
