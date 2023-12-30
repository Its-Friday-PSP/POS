using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Product
{
    public class UpdateProductRequest
    {
        [FromQuery]
        public Guid ProductId { get; set; }

        [FromBody]
        public ProductDTO Product { get; set; }
    }
}
