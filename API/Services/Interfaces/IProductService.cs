using API.Model;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(Product product);
        public Product GetProduct(Guid productId);
        public bool UpdateProduct(Guid productId, Product product);
        public bool DeleteProduct(Guid productId);
    }
}
