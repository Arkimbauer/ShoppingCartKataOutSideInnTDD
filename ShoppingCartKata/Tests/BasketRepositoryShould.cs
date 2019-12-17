using System;
using Xunit;

namespace ShoppingCartKata.Tests
{
    public class BasketRepositoryShould
    {
        private readonly ShoppingBasketShould _shoppingBasketShould = new ShoppingBasketShould();
        private DateTime _date = new DateTime(2019,03,12);

        [Fact]
        public void SaveOneShoppingBasket()
        {
            var shoppingBasketRepository = new BasketRepository();

            const string userId = "1";
            const string productId = "10002";
            const int quantity = 2;
            var item = new Item(productId, quantity);

            var shoppingBasket = new Basket(userId, _date);
            shoppingBasket.AddItem(item);

            shoppingBasketRepository.Save(shoppingBasket, userId);

            var expectedShoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }
    }
}   