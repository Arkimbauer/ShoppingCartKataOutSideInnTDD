using NSubstitute;
using Xunit;

namespace ShoppingCartKata.Tests
{
    public class BasketServiceShould
    {
        [Fact]
        public void SaveShoppingBasketOnBasketRepository()
        {
            var shoppingBasketRepository = Substitute.For<IShoppingBasketRepository>();
            var shoppingBasketService = new ShoppingBasketService(shoppingBasketRepository);
            
            const string userId = "1";
            const string productId = "10002";
            const int quantity = 2;
            var item = new Item(productId, quantity);

            var shoppingBasket = new ShoppingBasket(userId);
            shoppingBasket.AddItem(item);

            shoppingBasketService.AddItem(userId, productId, 2);

            shoppingBasketRepository.Received().Save(shoppingBasket);
        }
        
    }
}           