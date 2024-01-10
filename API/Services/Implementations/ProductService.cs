using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Stripe;

using Product = API.Model.Product;

namespace API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Model.Product CreateProduct(Model.Product product)
        {
            var createdProduct = _productRepository.CreateProduct(product);

            var offerOptions = new ProductCreateOptions
            {
                Name = createdProduct.Name, Description = createdProduct.Description,
            };

            var productService = new Stripe.ProductService();
            var stripeProduct = productService.Create(offerOptions);

            createdProduct.StripeId = stripeProduct.Id;

            _productRepository.UpdateProduct(createdProduct.Id, createdProduct);

            return createdProduct;
        }

        public bool DeleteProduct(Guid productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Model.Product GetProduct(Guid productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds)
        {
            return _productRepository.GetProducts(productIds);
        }

        public bool UpdateProduct(Guid productId, Product product)
        {
            return _productRepository.UpdateProduct(productId, product);
        }

    }
}
