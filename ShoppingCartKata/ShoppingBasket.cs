using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartKata
{
    public class ShoppingBasket
    {
        private readonly string _userId;
        private readonly List<Item> _items = new List<Item>();

        public ShoppingBasket(string userId)
        {
            _userId = userId;
        }

        public void AddItem(Item item)  
        {
            CheckRepeatProducts(item);
        }

        private void CheckRepeatProducts(Item newItem)
        {
            foreach (var item in _items.Where(item => item.GetProduct() == newItem.GetProduct()))
            {
                item.AddQuantity(newItem.GetQuantity());
                return;
            }

            _items.Add(newItem);
        }

        protected bool Equals(ShoppingBasket other)
        {
            return this._items.Count == other._items.Count && _items.All(item => other._items.Contains(item));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((ShoppingBasket) obj);
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