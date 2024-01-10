using API.Model;
using API.Repositories.Interfaces;

namespace API.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public Product CreateProduct(Product product)
        {
            product.Id = Guid.NewGuid();

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public bool DeleteProduct(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(x => x!.Id == productId);
            
            if(product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }

        public Product GetProduct(Guid productId)
        {
            return _context.Products.FirstOrDefault(product => product.Id == productId)!;
        }

        public IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds)
        {
            return _context.Products.Where(x => productIds.Contains(x.Id));
        }

        public bool UpdateProduct(Guid productId, Product product)
        {
            var oldProduct = _context.Products.FirstOrDefault(product => product.Id == productId);

            if (oldProduct == null)
            {
                return false;
            }

            oldProduct = product;

            return true;
        }
    }
}
