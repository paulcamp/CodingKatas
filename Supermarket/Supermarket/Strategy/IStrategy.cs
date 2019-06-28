using Supermarket.Entity;
using Supermarket.Persistence;

namespace Supermarket.Strategy
{
    public interface IStrategy
    {
        void Apply();
    }

    public abstract class BaseStrategy : IStrategy
    {
        public string Id { get; set; }
        public string Description { get; set; }

        private InMemoryPromotionPersistence _promoDatabase;

        protected BaseStrategy(string id, string description, InMemoryPromotionPersistence promoDatabase)
        {
            Id = id;
            Description = description;
            _promoDatabase = promoDatabase;
        }

        public void Apply()
        {
            if(_promoDatabase.HasPromotion(Id))
            {
                //TODO: handle already exists error better;
                throw new System.Exception("Promotion already exists");
            }

            var applicability = ApplyApplicability();
            var discount = ApplyDiscount();
            _promoDatabase.AddPromotion(new Promotion(Id, Description, applicability, discount));

        }

        protected abstract IApplicability ApplyApplicability();

        protected abstract IDiscount ApplyDiscount();

    }

    public class MultiBuyPercentStrategy : BaseStrategy
    {
        private decimal _percent;
        private int _qualifyingQuantity;

        public MultiBuyPercentStrategy(string id, string description, int qualifyingQuantity, decimal percent, InMemoryPromotionPersistence promoDatabase) : base(id, description, promoDatabase)
        {
            _percent = percent;
            _qualifyingQuantity = qualifyingQuantity;
        }

        protected override IApplicability ApplyApplicability()
        {
            return new MultiApplicability(_qualifyingQuantity);
        }

        protected override IDiscount ApplyDiscount()
        {
            return new PercentDiscount(_percent);
        }
    }


    public class MultiBuyValueStrategy : BaseStrategy
    {
        private decimal _value;
        private int _qualifyingQuantity;

        public MultiBuyValueStrategy(string id, string description, int qualifyingQuantity, decimal value, InMemoryPromotionPersistence promoDatabase) : base(id, description, promoDatabase)
        {
            _value = value;
            _qualifyingQuantity = qualifyingQuantity;
        }

        protected override IApplicability ApplyApplicability()
        {
            return new MultiApplicability(_qualifyingQuantity);
        }

        protected override IDiscount ApplyDiscount()
        {
            return new ValueDiscount(_value);
        }
    }

}
