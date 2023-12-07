using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutKata.Models;

namespace CheckoutKata
{
    public class CheckoutService
    {
        private IQueryable<Product> _products;
        private readonly ICollection<OrderItem> _items;

        public CheckoutService(string user, IQueryable<Product> products)
        {
            User = user;
            _items = new List<OrderItem>();
            _products = products;
        }

        public string User { get; init; }

        public IEnumerable<IReadOnlyOrderItem> Items => _items;

        public double Discount { get; private set; }

        public double Total { get; private set; }

        public void Add(string sku, int quantity)
        {
            var item = _items.FirstOrDefault(m => m.ProductSKU == sku);
            if (item != null)
            {
                item.AddQuantity(quantity);
            }
            else
            {
                var product = _products.FirstOrDefault(m => m.SKU == sku)  // TODO: Use async method (needs EntityFramework Assembly)
                    ?? throw new ArgumentException($"provided SKU {sku} is not valid.", nameof(sku));
                _items.Add(new OrderItem(product, quantity));
            }

            Discount = _items.Select(m => m.Discount).DefaultIfEmpty(0).Sum();
            Total = _items.Select(m => m.Amount).DefaultIfEmpty(0).Sum();
        }
    }
}
