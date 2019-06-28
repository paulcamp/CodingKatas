using Supermarket.Entity;
using Supermarket.Strategy;
using Supermarket.Persistence;
using NUnit.Framework;

namespace Supermarket.tests
{
    [TestFixture]
    public class MultiBuyPercentStrategyTest
    {
        [Test]
        public void HappyPath_MultiBuyPromotionIsApplied()
        {
            //arrange
            string id = "promo1";
            string description = "Buy 5 get 20% off";
            int qualifyingSize = 5;
            decimal percent = 20;
            var db = new InMemoryPromotionPersistence();
            var strategy = new MultiBuyPercentStrategy(id, description, qualifyingSize, percent, db);

            //act
            strategy.Apply();
                     
            //assert
            Assert.IsTrue(db.HasPromotion(id));
            var promo = db.GetPromotion(id);
            Assert.AreEqual(id, promo.Id);
            Assert.AreEqual(description, promo.Description);
            Assert.IsInstanceOf<PercentDiscount>(promo.Discount);
            Assert.IsInstanceOf<MultiApplicability>(promo.Applicability);
            Assert.AreEqual(percent, ((PercentDiscount)(promo.Discount)).GetPercent());
            Assert.AreEqual(qualifyingSize, promo.Applicability.GetApplicableSize());
        }

    }
}
