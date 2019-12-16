using System.Collections.Generic;
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

            var newShoppingBasket = new ShoppingBasket(userId);
            newShoppingBasket.AddItem(item);
            newShoppingBasket.AddItem(item);

            shoppingBasketRepository.Save(newShoppingBasket);

            var shoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            var expectedItem = new Item(productId, 2);
            var expectedShoppingBasket = new ShoppingBasket(userId);
            expectedShoppingBasket.AddItem(expectedItem);

            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }

        [Fact]
        public void AddQuantityToShoppingBasketItemIfAlreadyExistsAndThenAddNewItem()
        {
            var shoppingBasketRepository = new ShoppingBasketRepository();

            const string userId = "1";
            const string productIdTheHobbit = "10002";
            const string productIdBreakingBad = "20110";

            var itemTheHobbit = new Item(productIdTheHobbit, 1);
            var itemBreakingBad = new Item(productIdBreakingBad, 1);

            var newShoppingBasket = new ShoppingBasket(userId);
            newShoppingBasket.AddItem(itemTheHobbit);   
            newShoppingBasket.AddItem(new Item(productIdTheHobbit, 1));
            newShoppingBasket.AddItem(itemBreakingBad);
            newShoppingBasket.AddItem(new Item(productIdBreakingBad, 1));
            newShoppingBasket.AddItem(new Item(productIdBreakingBad, 1));
            newShoppingBasket.AddItem(new Item(productIdBreakingBad, 1));
            newShoppingBasket.AddItem(new Item(productIdBreakingBad, 1));
           

            shoppingBasketRepository.Save(newShoppingBasket);

            var shoppingBasket = shoppingBasketRepository.GetShoppingBasket(userId);

            var expectedItem = new Item(productIdBreakingBad, 5);
            var expectedShoppingBasket = new ShoppingBasket(userId);
            expectedShoppingBasket.AddItem(expectedItem);
            expectedShoppingBasket.AddItem(itemTheHobbit);
            expectedShoppingBasket.AddItem(itemTheHobbit);
            
            Assert.Equal(expectedShoppingBasket, shoppingBasket);
        }
    }
}