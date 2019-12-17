namespace ShoppingCartKata
{
    public interface IBasketRepository
    {
        void Save(Basket basket, string userId);
        void Update(Basket basket, string userId);
        bool ExistentUserIdShoppingBasket(string userId);
        Basket GetShoppingBasket(string userId);
    }
}                   