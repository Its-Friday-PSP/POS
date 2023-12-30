using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Customer
{
    public class GetCustomerRequest
    {
        [FromRoute(Name = "customerId")]
        public Guid CustomerId { get; set; }
    }
}
