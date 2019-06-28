using Supermarket.Entity;

namespace Supermarket.Persistence
{
    public interface IPromotionPersistence
    {
        bool HasPromotion(string id);
        Promotion GetPromotion(string id);
        void AddPromotion(Promotion promotion);
        void DeleteAll();
    }
}