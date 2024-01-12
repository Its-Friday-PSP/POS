using API.Model;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(Product product, IEnumerable<Guid> taxes);
        public Product GetProduct(Guid productId);
        public IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds);
        public bool UpdateProduct(Guid productId, Product product);
        public bool DeleteProduct(Guid productId);
    }
}
