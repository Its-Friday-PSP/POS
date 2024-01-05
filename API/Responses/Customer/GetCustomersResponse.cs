using API.DTOs;

namespace API.Responses.Customer
{
    public class GetCustomersResponse
    {
        public List<CustomerDTO> Customers { get; set; }

        public GetCustomersResponse(List<CustomerDTO> customers)
        {
            Customers = customers;
        }
    }
}
