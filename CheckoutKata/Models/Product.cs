using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public record Product
    {
        public Product(string sKU, double price, Promotion? promotion = null)
        {
            SKU = sKU;
            Price = price;
            Promotion = promotion;
        }

        public string SKU { get; init; }

        public double Price { get; init; }

        // each Product accept only one type of promotion
        public Promotion? Promotion { get; init; }
    }
}