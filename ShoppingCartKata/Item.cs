using System.Collections.Specialized;

namespace ShoppingCartKata
{
    public class Item
    {
        private readonly string _productId;
        private int _quantity;
        private readonly ProductsCatalog _productsCatalog = new ProductsCatalog();
        private readonly double _price;
        private readonly double _totalPrice;

        public Item(string productId, int quantity)
        {
            _productId = productId;
            _quantity = quantity;
            var product =_productsCatalog.GetProduct(productId);
            _price = product.Price;
            _totalPrice = _price * _quantity;
        }

        public double CalculateTotalPrice()
        {
            return _price * _quantity;
        }

        public string TextFormat()
        {
            var product = _productsCatalog.GetProduct(_productId);

            return $"\n- {_quantity.ToString()} x {product.NameTextFormat()} //{_quantity.ToString()} x {_price} = £{_totalPrice}";
        }

        public bool SameProduct(Item item)
        {
            return _productId == item._productId;
        }

        public void AddQuantity(Item item)
        {
            _quantity += item._quantity;
        }

        protected bool Equals(Item other)
        {
            return _productId == other._productId && _quantity == other._quantity;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Item) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_productId != null ? _productId.GetHashCode() : 0) * 397) ^ _quantity;
            }
        }
    }
}   