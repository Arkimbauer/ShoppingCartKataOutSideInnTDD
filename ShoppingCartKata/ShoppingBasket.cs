using System.Collections.Generic;

namespace ShoppingCartKata
{
    public class ShoppingBasket
    {
        private readonly string _userId;
        private readonly List<Item> _items = new List<Item>();

        public ShoppingBasket(string userId, Item item)
        {
            _userId = userId;
            CheckRepeatProducts(item);
        }

        private void CheckRepeatProducts(Item newItem)
        {
            foreach (var item in _items)
            {
                SumQuantityToRepeatProducts(newItem, item);
            }
        }

        private static void SumQuantityToRepeatProducts(Item newItem, Item item)
        {
            if (item.GetProduct() == newItem.GetProduct())
            {
                item.AddQuantity(newItem.GetQuantity());
            }
        }

        public string GetUserId()
        {
            return _userId;
        }

        protected bool Equals(ShoppingBasket other)
        {
            if (this._items.Count != other._items.Count)
                return false;

            foreach (var item in _items)
            {
                if (!other._items.Contains(item)) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingBasket) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_userId != null ? _userId.GetHashCode() : 0) * 397) ^ (_items != null ? _items.GetHashCode() : 0);
            }
        }
    }
}