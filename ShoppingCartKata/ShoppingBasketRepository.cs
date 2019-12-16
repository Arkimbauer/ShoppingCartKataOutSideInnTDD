using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace ShoppingCartKata
{
    public class ShoppingBasketRepository : IShoppingBasketRepository
    {
        private readonly List<ShoppingBasket> _shoppingBaskets;

        public ShoppingBasketRepository()
        {
            _shoppingBaskets = new List<ShoppingBasket>();
        }
        public void Save(ShoppingBasket shoppingBasket)
        {
            _shoppingBaskets.Add(shoppingBasket);
        }   

        public ShoppingBasket GetShoppingBasket(string userId)
        {
            return _shoppingBaskets.FirstOrDefault(shoppingBasket => shoppingBasket.GetUserId() == userId);
        }
    }
}   