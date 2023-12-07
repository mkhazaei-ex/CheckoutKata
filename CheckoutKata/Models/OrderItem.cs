using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class OrderItem
    {
        public OrderItem(Product product, int quantity)
        {
            ProductSKU = product.SKU;
            Product = product;
            Quantity = quantity;
        }

        public string ProductSKU { get; init; }

        public Product Product { get; init; }

        public int Quantity { get; private set; }

    }
}
