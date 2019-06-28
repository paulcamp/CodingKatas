using System.Collections.Generic;
using Supermarket.Entity;

namespace Supermarket.Persistence
{
    public class InMemoryProductPersistence : IProductPersistence
    {
        private readonly Dictionary<string, Product> _allProducts = new Dictionary<string, Product>();

        public Product GetProduct(string sku)
        {
            return _allProducts[sku]; //need error checking if sku does not exist
        }

        public void AddProduct(Product product)
        {
            _allProducts.Add(product.Sku, product);
        }

        public void DeleteProduct(string sku)
        {
            _allProducts.Remove(sku);
        }

        public void DeleteAll()
        {
            _allProducts.Clear();
        }
    }
}