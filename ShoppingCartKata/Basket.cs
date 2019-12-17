using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartKata
{
    public class Basket
    {
        private readonly string _userId;
        private readonly List<Item> _items = new List<Item>();
        private readonly DateTime _date = new DateTime(2019,03,12);

        public Basket(string userId, DateTime date)
        {
            _userId = userId;
            _date = date;
        }

        public void AddItem(Item item)  
        {
            foreach (var existingItem in _items.Where(item2 => item2.SameProduct(item)))
            {
                existingItem.AddQuantity(item);
                return;
            }

            _items.Add(item);
        }

        public string TextFormat()
        {
            var stringItems = string.Empty;
            double totalPrice = 0;

            foreach (var item in _items)
            {
                stringItems += item.TextFormat();
                totalPrice += item.CalculateTotalPrice();
            }

            return $" - {_date:dd/MM/yyyy} " +
                   stringItems +
                   $"\n- Total: £{totalPrice}";
        }

        protected bool Equals(Basket other)
        {
            return this._items.Count == other._items.Count && _items.All(item => other._items.Contains(item));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Basket) obj);
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