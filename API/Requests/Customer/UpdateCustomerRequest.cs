using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        [FromQuery]
        public Guid CustomerId { get; set; }

        [FromBody]
        public CustomerDTO Customer { get; set; }
    }
}
