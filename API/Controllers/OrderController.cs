using API.DTOs;
using API.Model;
using API.Requests.Order;
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
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
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
        public ActionResult<OrderItem> AddOrderItem([FromBody] OrderItemDTO orderItem)
        {
            var item = _orderService.AddOrderItem(_mapper.Map<OrderItem>(orderItem));

            return item == null ? NotFound() : Ok();
        }

        [HttpDelete("{orderId}/orderItem/{orderItemIndex}")]
        public ActionResult<Order> RemoveOrderItem([FromRoute] Guid orderId, [FromRoute] int orderItemIndex)
        {
            bool success = _orderService.RemoveOrderItem(orderId, orderItemIndex);
            return success ? Ok() : NotFound();
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(Guid orderId)
        {
            bool success = _orderService.DeleteOrder(orderId);
            return success ? Ok() : NotFound();
        }

        [HttpPut("tip/{orderId}")]
        public ActionResult<Order> AddTip([FromRoute] Guid orderId, [FromBody] AddTipRequest request)
        {
            var tip = _mapper.Map<Tip>(request.Tip);

            var order = _orderService.AddTip(orderId, tip);

            return order == null ? NotFound() : Ok(order);
        }
    }
}