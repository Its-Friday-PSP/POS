using API.Model;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(Product product);
        public Product GetProduct(Guid productId);
        public Product UpdateProduct(Guid productId, Product product);
        public Product DeleteProduct(Guid productId);
    }
}
