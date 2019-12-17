using System.Collections.Generic;
using ShoppingCartKata.Tests;

namespace ShoppingCartKata
{
    public class ShoppingBasketService
    {
        private readonly IShoppingBasketRepository _shoppingBasketRepository;

        public ShoppingBasketService(IShoppingBasketRepository shoppingBasketRepository)
        {
            _shoppingBasketRepository = shoppingBasketRepository;
        }

        public void AddItem(string userId, string productId, int quantity)
        {
            if (_shoppingBasketRepository.ExistentUserIdShoppingBasket(userId))
            {
                var shoppingBasket = _shoppingBasketRepository.GetShoppingBasket(userId);
                shoppingBasket.AddItem(new Item(productId, quantity));
                _shoppingBasketRepository.Update(shoppingBasket, userId);
            }

            if (!_shoppingBasketRepository.ExistentUserIdShoppingBasket(userId))
            {
                var item = new Item(productId, quantity);
                var shoppingBasket = new ShoppingBasket(userId);
                shoppingBasket.AddItem(item);
                _shoppingBasketRepository.Save(shoppingBasket, userId);
            }
        }   

        public ShoppingBasket BasketFor(string userId)
        {
            return _shoppingBasketRepository.GetShoppingBasket(userId);
        }
    }
}   