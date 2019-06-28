namespace Supermarket.Entity
{
    public class Product
    {
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Promotion Promotion { get; set; }

        public Product(string sku, string description, decimal price, Promotion promotion)
        {
            Sku = sku;
            Description = description;
            Price = price;
            Promotion = promotion;
        }
    }
}
