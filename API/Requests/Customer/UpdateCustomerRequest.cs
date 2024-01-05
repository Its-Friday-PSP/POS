using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        [FromBody]
        public CustomerDTO Customer { get; set; }
    }
}
