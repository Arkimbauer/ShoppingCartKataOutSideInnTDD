using Xunit;

namespace ShoppingCartKata.Tests
{
    public class BasketRepositoryShould
    {
        private readonly ShoppingBasketShould _shoppingBasketShould = new ShoppingBasketShould();

        [Fact]
        public void SaveOneShoppingBasket()
        {
            var shoppingBasketRepository = new BasketRepository();

            const string userId = "1";
            const string productId = "10002";
            const int quantity = 2;
            var item = new Item(productId, quantity);

            var shoppingBasket = new Basket(userId);
            shoppingBasket.AddItem(item);

            shoppingBasketRepository.Save(shoppingBasket, userId);

            var expectedShoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }
    }
}   