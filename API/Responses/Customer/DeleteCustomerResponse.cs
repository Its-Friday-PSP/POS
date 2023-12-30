using API.DTOs;

namespace API.Responses.Customer
{
    public class DeleteCustomerResponse
    {
        public CustomerDTO Customer { get; set; }

        public DeleteCustomerResponse(CustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
