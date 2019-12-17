namespace ShoppingCartKata
{
    public interface IShoppingBasketRepository
    {
        void Save(ShoppingBasket shoppingBasket, string userId);
        void Update(ShoppingBasket shoppingBasket, string userId);
        bool ExistentUserIdShoppingBasket(string userId);
        ShoppingBasket GetShoppingBasket(string userId);
    }
}               