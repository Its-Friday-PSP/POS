using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public ActionResult<IEnumerable<Order>> GetOrder(string orderId)
        {
            return Ok(_orderService.GetOrder(orderId));
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            return Ok(_orderService.CreateOrder(order));
        }

        [HttpPost("{orderId}/orderItem")]
        public ActionResult<Order> AddOrderItem(
            [FromQuery] string orderId,
            [FromBody] OrderItem orderItem)
        {
            System.Console.WriteLine("hello");
            return Ok(_orderService.AddOrderItem(orderId, orderItem));
        }

        [HttpDelete("{orderId}/orderItem/{orderItemIndex}")]
        public ActionResult<Order> RemoveOrderItem(string orderId, int orderItemIndex)
        {
            System.Console.WriteLine(orderId + ", " + orderItemIndex);
            return Ok(_orderService.RemoveOrderItem(orderId, orderItemIndex));
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(string orderId)
        {
            return Ok(_orderService?.DeleteOrder(orderId));
        }
    }
}