using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Product CreateProduct(Product product);
        public Product GetProduct(Guid productId);
        public Product UpdateProduct(Guid productId, Product product);
        public Product DeleteProduct(Guid productId);
    }
}
