using API.DTOs;
using API.Model;
using API.Requests.Order;
using API.Responses.Order;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IDiscountService discountService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
            _discountService = discountService;
        }

        [HttpGet("{orderId}")]
        public ActionResult<IEnumerable<Order>> GetOrder(Guid orderId)
        {
            return Ok(_orderService.GetOrder(orderId));
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request.Order);
            return Ok(_orderService.CreateOrder(order));
        }

        [HttpPost("{orderId}/orderItem")]
        public ActionResult<Order> AddOrderItem(
            [FromQuery] Guid orderId,
            [FromBody] OrderItemDTO orderItem)
        {
            System.Console.WriteLine("hello");
            
            return Ok(_orderService.AddOrderItem(orderId, _mapper.Map<OrderItem>(orderItem)));
        }

        [HttpDelete("{orderId}/orderItem/{orderItemIndex}")]
        public ActionResult<Order> RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            System.Console.WriteLine(orderId + ", " + orderItemIndex);
            return Ok(_orderService.RemoveOrderItem(orderId, orderItemIndex));
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(Guid orderId)
        {
            return Ok(_orderService.DeleteOrder(orderId));
        }

        [HttpPut("tip/{orderId}")]
        public ActionResult<Order> AddTip([FromRoute] Guid orderId, [FromBody] AddTipRequest request)
        {
            var tip = _mapper.Map<Tip>(request.Tip);

            var order = _orderService.AddTip(orderId, tip);

            return order == null ? NotFound() : Ok(order);
        }

        [HttpGet("discount/{discountId}")]
        public ActionResult<DiscountDTO> GetDiscount([FromRoute] string discountId)
        {
            var discount = _discountService.GetDiscount(discountId);

            return discount == null ? NotFound() : Ok(discount);
        }

        [HttpGet("discounts")]
        public ActionResult<IEnumerable<DiscountDTO>> GetDiscounts()
        {
            var discounts = _discountService.GetDiscounts();
            var discountDTOs = _mapper.Map<IEnumerable<Discount>>(discounts);

            return Ok(discountDTOs);
        }

        [HttpPost("discount")]
        public ActionResult<DiscountDTO> CreateDiscount([FromBody] DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);
            var newDiscount = _discountService.CreateDiscount(discount);

            return newDiscount == null ? NotFound() : Ok(newDiscount);
        }

        [HttpPut("discount/{discountId}")]
        public IActionResult UpdateDiscount([FromRoute] string discountId, DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);
            bool success = _discountService.UpdateDiscount(discountId, discount);

            return success ? Ok() : NotFound();
        }

        [HttpGet("checkDiscount/{discountId}")]
        public ActionResult<ApplyDiscountResponse> CheckDiscount([FromRoute] string stringId)
        {
            var discount = _discountService.CheckDiscount(stringId);

            return discount == null ? NotFound() : Ok(new ApplyDiscountResponse(discount));
        }

    }
}