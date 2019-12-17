using System.Collections.Generic;
using ShoppingCartKata.Tests;

namespace ShoppingCartKata
{
    public class ShoppingBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public ShoppingBasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public void AddItem(string userId, string productId, int quantity)
        {
            if (_basketRepository.ExistentUserIdShoppingBasket(userId))
            {
                var shoppingBasket = _basketRepository.GetShoppingBasket(userId);
                shoppingBasket.AddItem(new Item(productId, quantity));
                _basketRepository.Update(shoppingBasket, userId);
            }

            if (!_basketRepository.ExistentUserIdShoppingBasket(userId))
            {
                var item = new Item(productId, quantity);
                var shoppingBasket = new Basket(userId);
                shoppingBasket.AddItem(item);
                _basketRepository.Save(shoppingBasket, userId);
            }
        }       

        public string BasketFor(string userId)
        {
            var shoppingBasket = _basketRepository.GetShoppingBasket(userId);
            return shoppingBasket.TextFormat();
        }
    }
}   