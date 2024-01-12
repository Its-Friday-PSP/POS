using API.DTOs;
using API.DTOs.Request;
using API.Model;
using API.Requests.Customer;
using API.Responses.Customer;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("{customerId}")]
        public ActionResult<GetCustomerResponse> GetCustomer([FromRoute] GetCustomerRequest request)
        {

            /*var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var requestCustomerId = Guid.Parse(identity.FindFirst("Id").Value);
                Console.WriteLine(requestCustomerId);
            }*/
            
            var customerDomain = _customerService.GetCustomer(request.CustomerId);

            if(customerDomain == null)
            {
                return NotFound();
            }

            var response = new GetCustomerResponse(_mapper.Map<CustomerDTO>(customerDomain));
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetCustomerResponse> GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            var response = new GetCustomersResponse(_mapper.Map<List<CustomerDTO>>(customers));
            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Email already exists
        public ActionResult<CustomerDTO> CreateCustomer(CustomerCreationRequestDTO request)
        {
            var customerDomain = _mapper.Map<Customer>(request);
            var createdCustomer = _customerService.CreateCustomer(customerDomain, request.AvaialableDiscounts);
            var response = _mapper.Map<CustomerDTO>(createdCustomer);
            return Ok(response);
        }

        [HttpPut("{customerId}")]
        public ActionResult<UpdateCustomerResponse> UpdateCustomer(
            UpdateCustomerRequest request,
            Guid customerId
        ) {
            var customer = _mapper.Map<Customer>(request.Customer);
            var updateCustomer = _customerService.UpdateCustomer(customerId, customer);

            //var updateCustomer = _customerService.UpdateCustomer(request.CustomerId, customer);
            //var response = new UpdateCustomerResponse(_mapper.Map<CustomerDTO>(updateCustomer));

            return Ok();
        }

        [HttpDelete("{customerId}")]
        public ActionResult<DeleteCustomerResponse> DeleteCustomer(DeleteCustomerRequest request)
        {
            var deletedCustomer = _customerService.DeleteCustomer(request.CustomerId);
            var response = new DeleteCustomerResponse(_mapper.Map<CustomerDTO>(deletedCustomer));
            return Ok(response);
        }
    }
}