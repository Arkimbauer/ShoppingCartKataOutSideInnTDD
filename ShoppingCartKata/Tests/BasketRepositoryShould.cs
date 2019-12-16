using Xunit;

namespace ShoppingCartKata.Tests
{
    public class BasketRepositoryShould
    {
        [Fact]
        public void SaveOneShoppingBasket()
        {
            var shoppingBasketRepository = new ShoppingBasketRepository();

            string userId = "1";
            string productId = "10002";
            int quantity = 2;
            var item = new Item(productId, quantity);

            var shoppingBasket = new ShoppingBasket(userId, item);

            shoppingBasketRepository.Save(shoppingBasket);

            var expectedShoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }
    }
}