using API.DTOs;

namespace API.Responses.Product
{
    public class GetProductResponse
    {
        public ProductDTO Product { get; set; }

        public GetProductResponse(ProductDTO product)
        {
            Product = product;
        }
    }
}
