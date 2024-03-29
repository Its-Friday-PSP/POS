﻿using API.Model;

namespace API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Product CreateProduct(Product product);
        public Product GetProduct(Guid productId);
        public IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds);
        public bool UpdateProduct(Guid productId, Product product);
        public bool DeleteProduct(Guid productId);
    }
}
