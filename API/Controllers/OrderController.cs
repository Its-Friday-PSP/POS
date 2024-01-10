using API.DTOs;
using API.DTOs.Request;
using API.DTOs.Response;
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
        public ActionResult<OrderCreationResponseDTO> CreateOrder(OrderCreationRequestDTO request)
        {
            Order order = _orderService.CreateOrder(request);
            var response = _mapper.Map<OrderCreationResponseDTO>(order);

            return Ok(response);
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

    }
}