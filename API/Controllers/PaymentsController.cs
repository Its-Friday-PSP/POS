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

        //const string endpointSecret = "whsec_8cd6e873a43848838d76b4fe16b68aed995642b3dd5edb27e51a83293505e63a";

        private readonly IPaymentService _paymentsService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        //private readonly IOfferRepository _offerRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentsRepository _paymentRepository;



        public PaymentsController(
            IPaymentService paymentsService,
            IMapper mapper,
            IConfiguration configuration,
            IHttpContextAccessor httpContext,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IPaymentsRepository paymentsRepository)
        {
            _paymentsService = paymentsService;
            _mapper = mapper;
            _configuration = configuration;
            _httpContext = httpContext;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _paymentRepository = paymentsRepository;
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
            if(order.OrderType == OrderTypeDTO.SERVICE)
            {
                var services = ((ServiceOrder)order).Services;
                products = services.Select(service => (service.StripeId!, 1, (int)(service.Price * 100))).Distinct().ToList();
            }
            else
            {
                var orderItems = ((ProductOrder)order).OrderItems;
                var productIds = orderItems.Select(item => item.ProductId);
                var productsDomain = productIds.Select(productId => (productId, _productRepository.GetProduct(productId))).ToDictionary(item => item.productId);
                products = orderItems.Select(orderItem => (productsDomain[orderItem.ProductId].Item2.StripeId!, orderItem.Amount, (int)(_productRepository.GetProduct(orderItem.ProductId)!.Price! * 100))).Distinct().ToList();
            }

            var customer = _customerRepository.GetCustomer(userId);

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
                Metadata = new Dictionary<string, string>() { {"orderId", orderId.ToString()} },
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

                Customer = customer.StripeId,


            };

            var service = new SessionService();
            var session = service.Create(options);

            return session.Url;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> SuccessfullPaymentHandler()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            const string endpointSecret = "whsec_8cd6e873a43848838d76b4fe16b68aed995642b3dd5edb27e51a83293505e63a";

            //Console.WriteLine(json);
            var stripeEvent = (Event)null;
            try
            {
                stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //Console.WriteLine(stripeEvent.Type.ToString());
            try
            {
                var stripeEvent2 = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                var a = 5;
                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {

                    var checkoutSession = stripeEvent.Data.Object as Stripe.Checkout.Session;
                    var customerID = checkoutSession.CustomerId;

                    var orderId = Guid.Parse(checkoutSession.Metadata["orderId"]);
                    Console.WriteLine("orderId=" + orderId);
                    var order = _orderRepository.GetOrder(orderId);

                    //_paymentRepository.CreatePayment(new Payment(
                    //    Guid.NewGuid(),
                    //    orderId,
                    //    Enumerators.PaymentType.CARD,
                    //    Enumerators.PaymentState.COMPLETED,
                    //    order.Price,
                    //    DateTime.Now
                    //    ));
                    //_orderRepository.UpdateOrderStatus(order, OrderStatus.PAID);

                    /*var options = new SessionListLineItemsOptions
                    {
                        Limit = 10
                    };
                    var service = new SessionService();
                    StripeList<LineItem> lineItems = service.ListLineItems(checkoutSession.Id, options);



                    var productIds = lineItems.Data.ToArray().Select(li => li.Price.ProductId);

                    Console.WriteLine("productId=" + lineItems.Data.ToArray()[0].Price.ProductId);

                    var user = await _userRepository.GetUserAsync(user => user.StripeId == customerID);
                    var offer = await _offerRepository.GetOfferAsync(offer => offer.StripeId == productId);


                    if (user != null && offer != null)
                    {
                        await _subscriptionRepository.AddSubscriptionAsync(new Models.Entities.Subscription(
                            user.Id,
                            offer.Id,
                            DateTime.Now
                            ));
                        await _subscriptionRepository.SaveChangesAsync();
                    }*/
                }


                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }

        }

    }
}
