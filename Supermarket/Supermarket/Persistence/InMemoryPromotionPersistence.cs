using System.Collections.Generic;
using Supermarket.Entity;

namespace Supermarket.Persistence
{
    public class InMemoryPromotionPersistence : IPromotionPersistence
    {
        private readonly Dictionary<string, Promotion> _allPromotions = new Dictionary<string, Promotion>();
        public bool HasPromotion(string id)
        {
            return _allPromotions.ContainsKey(id);
        }

        public Promotion GetPromotion(string id)
        {
            return _allPromotions[id];
        }

        public void AddPromotion(Promotion promotion)
        {
            _allPromotions.Add(promotion.Id, promotion);
        }

        public void DeleteAll()
        {
            _allPromotions.Clear();
        }
    }
}