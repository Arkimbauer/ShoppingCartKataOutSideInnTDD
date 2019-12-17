using System.Collections.Generic;
using System.Linq;
using Xunit.Sdk;

namespace ShoppingCartKata
{
    public class BasketRepository : IBasketRepository
    {
        private readonly Dictionary<string, Basket> _shoppingBasketsDictionary;

        public BasketRepository()
        {
            _shoppingBasketsDictionary = new Dictionary<string, Basket>();
        }
        public void Save(Basket basket, string userId)
        {
            _shoppingBasketsDictionary.Add(userId, basket);
        }   

        public void Update(Basket basket, string userId)
        {
            _shoppingBasketsDictionary.Remove(userId);
            _shoppingBasketsDictionary.Add(userId, basket);
        }

        public bool ExistentUserIdShoppingBasket(string userId)
        {
            return _shoppingBasketsDictionary.ContainsKey(userId);
        }

        public Basket GetShoppingBasket(string userId)
        {
            return _shoppingBasketsDictionary[userId];
        }
    }
}   