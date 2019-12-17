using System;
using System.Collections.Generic;

namespace ShoppingCartKata
{
    public class ProductsCatalog
    {
        private readonly Dictionary<string, Product> _productsDictionary;

        public ProductsCatalog()
        {
            _productsDictionary = new Dictionary<string, Product>
            {
                {"10002", new Product("The Hobbit", 5.00)},
                {"20110", new Product("Breaking Bad", 7.00)},
            };
        }

        public Product GetProduct(string productId)
        {
            return _productsDictionary[productId];
        }   
    }
}