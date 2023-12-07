using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class OrderItem : IReadOnlyOrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), $"must be bigger than zero");

            ProductSKU = product.SKU;
            Product = product;
            Quantity = quantity;
            Calculate();
        }

        public string ProductSKU { get; init; }

        public Product Product { get; init; }

        public int Quantity { get; private set; }

        public double Discount { get; private set; } = 0;

        public double Amount { get; private set; } = 0;

        public void AddQuantity(int quantity)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), $"must be bigger than zero");

            Quantity += quantity;
            Calculate();
        }


        private void Calculate()
        {
            var total = Quantity * Product.Price;
            Amount = Math.Min(Product.Promotion?.Apply(Product.Price, Quantity) ?? total, total);
            Discount = total - Amount;
        }
    }
}
