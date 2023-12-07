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
            ProductSKU = product.SKU;
            Product = product;
            Quantity = quantity;
            Calculate();
        }

        public string ProductSKU { get; init; }

        public Product Product { get; init; }

        public int Quantity { get; private set; }

        public double Discount { get; private set; }

        public double Amount { get; private set; }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
            Calculate();
        }


        private void Calculate()
        {
            var total = Quantity * Product.Price;
            Amount = Math.Min(Product.Promotion?.Apply(Product, Quantity) ?? total, total);
            Discount = total - Amount;
        }
    }
}
