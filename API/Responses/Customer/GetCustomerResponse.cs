using API.DTOs;

namespace API.Responses.Customer
{
    public class GetCustomerResponse
    {
        public CustomerDTO Customer { get; set; }

        public GetCustomerResponse(CustomerDTO customer)
        {
            Customer = customer;
        }
    }
}
