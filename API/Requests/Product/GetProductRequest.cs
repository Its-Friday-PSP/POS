using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Requests.Product
{
    public class GetProductRequest
    {
        [FromRoute(Name = "productId")]
        public Guid ProductId { get; set; }
    }
}
