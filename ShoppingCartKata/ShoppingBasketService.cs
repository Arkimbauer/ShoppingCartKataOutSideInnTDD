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
            var item = new Item(productId, quantity);
            var shoppingBasket = new ShoppingBasket(userId, item);
            _shoppingBasketRepository.Save(shoppingBasket);
        }   

        public string BasketFor(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}   