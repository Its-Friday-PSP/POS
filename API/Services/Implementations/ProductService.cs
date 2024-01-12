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
        private readonly ITaxRepository _taxRepository;

        public ProductService(IProductRepository productRepository, ITaxRepository taxRepository)
        {
            _productRepository = productRepository;
            _taxRepository = taxRepository;
        }

        public Model.Product CreateProduct(Model.Product product, IEnumerable<Guid> taxes)
        {
            var createdProduct = _productRepository.CreateProduct(product);
            var selectedTaxes = _taxRepository.GetTaxes(taxes).Select(x => new ProductTaxItem() { ProductId = product.Id, TaxId = x.Id }).ToList();

            createdProduct.Taxes = selectedTaxes;

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
