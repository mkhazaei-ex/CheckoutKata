using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public record Product
    {
        public Product(string sKU, double price, IPromotion? promotion = null)
        {
            if (price < 0) throw new ArgumentOutOfRangeException(nameof(price), $"must be equal or bigger than zero");

            SKU = sKU;
            Price = price;
            Promotion = promotion;
        }

        public string SKU { get; init; }

        public double Price { get; init; }

        // each Product accept only one type of promotion
        public IPromotion? Promotion { get; init; }
    }
}