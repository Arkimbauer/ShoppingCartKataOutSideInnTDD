using NSubstitute;
using Xunit;

namespace ShoppingCartKata.Tests
{
    public class BasketServiceShould
    {
        [Fact]
        public void SaveShoppingOnBasketOnBasketRepository()
        {   
            var shoppingBasketRepository = Substitute.For<IBasketRepository>();
            var shoppingBasketService = new ShoppingBasketService(shoppingBasketRepository);
            
            const string userId = "1";
            const string productId = "10002";
            const int quantity = 2;
            var item = new Item(productId, quantity);

            var shoppingBasket = new Basket(userId);
            shoppingBasket.AddItem(item);

            shoppingBasketService.AddItem(userId, productId, 2);

            shoppingBasketRepository.Received().Save(shoppingBasket, userId);
        }
        
        [Fact]
        public void AddNewItemToExistentShoppingBasketRepository()
        {
            var shoppingBasketRepository = Substitute.For<IBasketRepository>();
            var shoppingBasketService = new ShoppingBasketService(shoppingBasketRepository);

            const string userId = "1";
            const string productId = "10002";
            const int quantity = 1;

            var existingShoppingBasket = new Basket(userId);
            existingShoppingBasket.AddItem(new Item(productId, 1));

            shoppingBasketRepository.GetShoppingBasket(userId).Returns(existingShoppingBasket);

            shoppingBasketRepository.ExistentUserIdShoppingBasket(userId).Returns(true);

            var shoppingBasket = new Basket(userId);
            shoppingBasket.AddItem(new Item(productId, 2));

            shoppingBasketService.AddItem(userId, productId, quantity);

            shoppingBasketRepository.Received().Update(shoppingBasket, userId);
        }

        [Fact]
        public void ReturnsBasketFromRepository()
        {
            var shoppingBasketRepository = Substitute.For<IBasketRepository>();
            var shoppingBasketService = new ShoppingBasketService(shoppingBasketRepository);

            const string userId = "1";

            shoppingBasketService.BasketFor(userId);
           
            shoppingBasketRepository.Received().GetShoppingBasket(userId);
        }
    }   
}                   