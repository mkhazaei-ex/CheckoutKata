using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public interface IReadOnlyOrderItem
    {
        public string ProductSKU { get; }

        public Product Product { get; }

        public int Quantity { get; }

        public double Discount { get; }

        public double Amount { get; }
    }
}
