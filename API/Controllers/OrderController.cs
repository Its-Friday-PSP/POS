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
        public async Task<ActionResult<OrderReceipt>> CreateOrder(OrderCreationRequestDTO request)
        {
            OrderReceipt orderReceipt = await _orderService.CreateOrder(request);

            return Ok(orderReceipt);
        }

        [HttpPost("{orderId}/orderItem")]
        public ActionResult<OrderDTO> AddOrderItem([FromRoute]Guid orderId, [FromBody] OrderItemCreationRequestDTO orderItemDto)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(orderItemDto);
            orderItem.OrderId = orderId;

            var order = _orderService.AddOrderItem(orderId, orderItem);
            var response = _mapper.Map<OrderDTO>(order);

            return Ok(response);
        }

        [HttpDelete("{orderId}/orderItem/{orderItemIndex}")]
        public ActionResult<OrderDTO> RemoveOrderItem(Guid orderId, int orderItemIndex)
        {
            System.Console.WriteLine(orderId + ", " + orderItemIndex);

            var order = _orderService.RemoveOrderItem(orderId, orderItemIndex);
            var response = _mapper.Map<OrderDTO>(order);

            return Ok(response);
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(Guid orderId)
        {
            return Ok(_orderService.DeleteOrder(orderId));
        }

        [HttpPut("tip/{orderId}")]
        public ActionResult<Order> AddTip([FromRoute] Guid orderId, [FromBody] long tip)
        {
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