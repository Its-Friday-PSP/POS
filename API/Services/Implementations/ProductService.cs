using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.CreateProduct(product);
        }

        public Product DeleteProduct(Guid productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Product GetProduct(Guid productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public Product UpdateProduct(Guid productId, Product product)
        {
           return _productRepository.UpdateProduct(productId, product);
        }
    }
}
