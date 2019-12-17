namespace ShoppingCartKata
{
    public class Product
    {
        private readonly string _name;
        public readonly double Price;

        public Product(string name, double price)
        {
            _name = name;
            Price = price;  
        }

        public string NameTextFormat()
        {
            return $"{_name.ToString()}";
        }
    }
}