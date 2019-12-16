using Xunit;

namespace ShoppingCartKata.Tests
{
    public class ShoppingBasketShould
    {
        [Fact]
        public void AddQuantityToShoppingBasketIfItemAlreadyExists()
        {
            var shoppingBasketRepository = new ShoppingBasketRepository();

            const string userId = "1";
            const string productId = "10002";
            const int quantity = 1;
            var item = new Item(productId, quantity);

            var newShoppingBasket = new ShoppingBasket(userId, item);

            shoppingBasketRepository.Save(newShoppingBasket);
            shoppingBasketRepository.Save(newShoppingBasket);

            var shoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            var expectedItem = new Item(productId, 2);
            var expectedShoppingBasket = new ShoppingBasket(userId, expectedItem);

            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }
    }
}