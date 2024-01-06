using API.DTOs;
using API.Model;
using API.Requests.Product;
using API.Responses.Product;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("{productId}")]
        public ActionResult<GetProductResponse> GetProduct([FromRoute] GetProductRequest request)
        {   
            var productDomain = _productService.GetProduct(request.ProductId);
            var response = new GetProductResponse(_mapper.Map<ProductDTO>(productDomain));
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            var productDomain = _mapper.Map<Product>(request.Product);
            var createdProduct = _productService.CreateProduct(productDomain);
            var response = new CreateProductResponse(_mapper.Map<ProductDTO>(createdProduct));
            return Ok(response);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(UpdateProductRequest request)
        {
            var product = _mapper.Map<Product>(request.Product);
            bool success = _productService.UpdateProduct(request.ProductId, product);
            
            if(!success)
            {
                return NotFound(); 
            }
            
            return Ok();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct([FromRoute] DeleteProductRequest request)
        {
            bool success = _productService.DeleteProduct(request.ProductId);
            
            if(!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}