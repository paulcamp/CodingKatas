using Supermarket.Entity;

namespace Supermarket.Persistence
{
    public interface IProductPersistence
    {
        Product GetProduct(string sku);

        void AddProduct(Product product);

        void DeleteProduct(string sku);

        void DeleteAll();

    }
}
