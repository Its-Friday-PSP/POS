using API.DTOs;

namespace API.Responses.Product
{
    public class CreateProductResponse
    {
        public ProductDTO Product { get; set; }

        public CreateProductResponse(ProductDTO product)
        {
            Product = product;
        }
    }
}
