using API.DTOs;

namespace API.Responses.Product
{
    public class DeleteProductResponse
    {
        public ProductDTO Product { get; set; }

        public DeleteProductResponse(ProductDTO product)
        {
            Product = product;
        }
    }
}
