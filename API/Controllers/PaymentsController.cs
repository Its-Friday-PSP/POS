using API.DTOs;
using API.Model;
using API.Repositories.Interfaces;
using API.Requests.Payments;
using API.Responses.Payments;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentsService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentsRepository, IMapper mapper)
        {
            _paymentsService = paymentsRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<CreatePaymentResponse> CreatePayment(CreatePaymentRequest request)
        {
            var paymentDomain = _mapper.Map<Payment>(request.Payment);
            var createdPayment = _paymentsService.CreatePayment(paymentDomain);
            var response = new CreatePaymentResponse(_mapper.Map<PaymentDTO>(createdPayment));

            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetPaymentsResponse> GetPayments()
        {
            var payments = _paymentsService.GetPayments();
            var response = new GetPaymentsResponse(_mapper.Map<List<PaymentDTO>>(payments));

            return Ok(response);
        }

        [HttpGet("{paymentId}")]
        public ActionResult<GetPaymentResponse> GetPayment([FromRoute] GetPaymentRequest request)
        {
            var paymentDomain = _paymentsService.GetPayment(request.PaymentId);
            
            if(paymentDomain == null)
            {
                return NotFound();
            }

            var response = new GetPaymentResponse(_mapper.Map<PaymentDTO>(paymentDomain));
            
            return Ok(response);
        }

        [HttpPut("{paymentId}")]
        public IActionResult UpdatePayment(UpdatePaymentRequest request, Guid paymentId)
        {
            var payment = _mapper.Map<Payment>(request.Payment);
            bool success = _paymentsService.UpdatePayment(paymentId, payment);

            if(!success)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{paymentId}")]
        public IActionResult DeletePayment(DeletePaymentRequest request)
        {
            bool success = _paymentsService.DeletePayment(request.PaymentId);

            if(!success)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
