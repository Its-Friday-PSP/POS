using Microsoft.AspNetCore.Mvc;

namespace API.Requests.Product
{
    public class DeleteProductRequest
    {
        [FromRoute(Name = "productId")]
        public Guid ProductId { get; set; }
    }
}
