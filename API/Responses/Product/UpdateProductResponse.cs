using API.DTOs;

namespace API.Responses.Product
{
    public class UpdateProductResponse
    {
        public ProductDTO Product { get; set; }

        public UpdateProductResponse(ProductDTO product)
        {
            Product = product;
        }
    }
}
