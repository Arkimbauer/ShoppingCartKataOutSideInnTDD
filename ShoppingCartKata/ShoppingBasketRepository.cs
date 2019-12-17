using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace ShoppingCartKata
{
    public class ShoppingBasketRepository : IShoppingBasketRepository
    {
        private readonly Dictionary<string, ShoppingBasket> _shoppingBasketsDictionary;

        public ShoppingBasketRepository()
        {
            _shoppingBasketsDictionary = new Dictionary<string, ShoppingBasket>();
        }
        public void Save(ShoppingBasket shoppingBasket, string userId)
        {
            _shoppingBasketsDictionary.Add(userId, shoppingBasket);
        }   

        public void Update(ShoppingBasket shoppingBasket, string userId)
        {
            _shoppingBasketsDictionary.Remove(userId);
            _shoppingBasketsDictionary.Add(userId, shoppingBasket);
        }

        public bool ExistentUserIdShoppingBasket(string userId)
        {
            return _shoppingBasketsDictionary.ContainsKey(userId);
        }

        public ShoppingBasket GetShoppingBasket(string userId)
        {
            return _shoppingBasketsDictionary[userId];
        }
    }
}   