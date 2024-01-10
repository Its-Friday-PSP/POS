using API.DTOs;
using API.Model;
using API.Repositories.Interfaces;
using API.Requests.Payments;
using API.Responses.Payments;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Stripe;
using Stripe.Checkout;
using System.Linq;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentsService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        //private readonly IOfferRepository _offerRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;



        public PaymentsController(
            IPaymentService paymentsService,
            IMapper mapper,
            IConfiguration configuration,
            IHttpContextAccessor httpContext,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _paymentsService = paymentsService;
            _mapper = mapper;
            _configuration = configuration;
            _httpContext = httpContext;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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

        [HttpPost("pay")]
        public ActionResult<string> GetPaymentLink([FromBody] Guid orderId)
        {
            var userId = Guid.Parse(((ClaimsIdentity)_httpContext.HttpContext.User.Identity).FindFirst("Id").Value);

            var order = _orderRepository.GetOrder(orderId);
            if(order is null)
            {
                return NotFound();
            }

            /*if(order.Status != OrderStatus.AWAITING_PAYMENT)
            {
                return BadRequest();
            }*/


            var products = new List<(String id, int quantity, int price)>();
            if(order.OrderType == Enumerators.OrderType.SERVICE)
            {
                var services = ((ServiceOrder)order).Services;
                products = services.Select(service => (service.Id.ToString(), 1, (int)(service.Price.Amount * 100))).Distinct().ToList();
            }
            else
            {
                var orderItems = ((ProductOrder)order).OrderItems;
                var productIds = orderItems.Select(item => item.ProductId);
                var productsDomain = productIds.Select(productId => _productRepository.GetProduct(productId));
                products = orderItems.Select(orderItem => (orderItem.ProductId.ToString(), orderItem.Amount, (int)(_productRepository.GetProduct(orderItem.ProductId)!.Price! * 100))).Distinct().ToList();
            }



            var options = new SessionCreateOptions
            {
                // Stripe calls the URLs below when certain checkout events happen such as success and failure.
                //SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}", // Customer paid.
                //SuccessUrl = "degano://stripe-redirect",
                SuccessUrl = "https://google.com",
                CancelUrl = "https://google.com",
                //CancelUrl = s_wasmClientURL + "failed",  // Checkout cancelled.
                PaymentMethodTypes = new List<string> // Only card available in test mode?
                {
                    "card"
                },
                LineItems = products.Select<(String id, int quantity, int price), SessionLineItemOptions>(product => new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = product.price, // Price is in USD cents.
                        Currency = "EUR",
                        /*ProductData = new SessionLineItemPriceDataProductDataOptions
                        {

                            Name = "Premium",
                            //Description = product.Description,
                            //Images = new List<string> { product.ImageUrl }
                        },*/
                        Product = product.id,
                    },
                    Quantity = product.quantity,
                }).ToList(),
                Mode = "payment", // One-time payment. Stripe supports recurring 'subscription' payments.

                Customer = userId.ToString(),


            };

            var service = new SessionService();
            var session = service.Create(options);

            return session.Url;
        }

    }
}
