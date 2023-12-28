using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public ActionResult<IEnumerable<Customer>> GetCustomer(Guid customerId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var requestCustomerId = Guid.Parse(identity.FindFirst("Id").Value);
                Console.WriteLine(requestCustomerId);
            }

            return Ok(_customerService.GetCustomer(customerId));
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            return Ok(_customerService.CreateCustomer(customer));
        }

        [HttpPut("{customerId}")]
        public ActionResult<Customer> UpdateCustomer([FromQuery] Guid customerId, [FromBody] Customer customer)
        {
            return Ok(_customerService.UpdateCustomer(customerId, customer));
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Customer> DeleteCustomer(Guid orderId)
        {
            return Ok(_customerService.DeleteCustomer(orderId));
        }
    }
}