using Supermarket.Entity;
using Supermarket.Strategy;
using Supermarket.Persistence;
using NUnit.Framework;

namespace Supermarket.tests
{
    [TestFixture]
    public class MultiBuyValueStrategyTest
    {
        [Test]
        public void HappyPath_MultiBuyPromotionIsApplied()
        {
            //arrange
            string id = "promo2";
            string description = "Buy 2 get one free";
            int qualifyingSize = 2;
            decimal valueOfSingleItem = 20;
            var db = new InMemoryPromotionPersistence();
            var strategy = new MultiBuyValueStrategy(id, description, qualifyingSize, valueOfSingleItem, db);

            //act
            strategy.Apply();

            //assert
            Assert.IsTrue(db.HasPromotion(id));
            var promo = db.GetPromotion(id);
            Assert.AreEqual(id, promo.Id);
            Assert.AreEqual(description, promo.Description);
            Assert.IsInstanceOf<ValueDiscount>(promo.Discount);
            Assert.IsInstanceOf<MultiApplicability>(promo.Applicability);
            Assert.AreEqual(valueOfSingleItem, ((ValueDiscount)(promo.Discount)).GetValue());
            Assert.AreEqual(qualifyingSize, promo.Applicability.GetApplicableSize());
        }
    }
}
