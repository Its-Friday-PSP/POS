using API.Model;
using API.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{productId}")]
        public ActionResult<IEnumerable<Product>> GetProduct(Guid productId)
        {
            return Ok(_productService.GetProduct(productId));
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            return Ok(_productService.CreateProduct(product));
        }

        [HttpPut("{productId}")]
        public ActionResult<Product> UpdateProduct([FromQuery] Guid productId, [FromBody] Product product)
        {
            return Ok(_productService.UpdateProduct(productId, product));
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Product> DeleteProduct(Guid orderId)
        {
            return Ok(_productService.DeleteProduct(orderId));
        }
    }
}