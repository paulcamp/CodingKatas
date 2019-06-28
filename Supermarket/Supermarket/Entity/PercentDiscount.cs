namespace Supermarket.Entity
{
    public class PercentDiscount : IDiscount
    {
        private readonly decimal _percent;

        public PercentDiscount(decimal percent)
        {
            _percent = percent;
        }

        public decimal Discount(decimal original)
        {
            return original * _percent / (decimal) 100.0;
        }
    }
}