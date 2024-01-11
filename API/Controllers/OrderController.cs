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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDTO> GetOrder(Guid orderId)
        {
            var order = _orderService.GetOrder(orderId);
            var orderDto = _mapper.Map<OrderDTO>(order);

            return order == null ? NotFound() : Ok(orderDto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder(OrderCreationRequestDTO request)
        {
            Order order = await _orderService.CreateOrder(request);
            var response = _mapper.Map<OrderDTO>(order);

            return Ok(response);
        }

        [HttpPost("{orderId}/orderItem")]
        public ActionResult<Order> AddOrderItem(
            [FromRoute]Guid orderId,
            [FromBody] OrderItem orderItem)
        {
            return Ok(_orderService.AddOrderItem(orderId, orderItem));
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

        [HttpPut("fulfill/{orderId}")]
        public ActionResult<OrderDTO> FulfillOrder(Guid orderId)
        {
            var completedOrder = _orderService.CompleteOrder(orderId);

            return completedOrder == null ? NotFound() : Ok(completedOrder);
        }

    }
}