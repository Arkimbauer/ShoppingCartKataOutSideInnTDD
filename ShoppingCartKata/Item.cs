namespace ShoppingCartKata
{
    public class Item
    {
        private readonly string _productId;
        private readonly int _quantity;

        public Item(string productId, int quantity)
        {
            _productId = productId;
            _quantity = quantity;
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