namespace Supermarket.Entity
{
    class ValueDiscount : IDiscount
    {
        private readonly decimal _value;

        public ValueDiscount(decimal initValue)
        {
            this._value = initValue;
        }
        public decimal Discount(decimal original)
        {
            return _value;
        }


    }
}