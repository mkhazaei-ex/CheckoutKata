using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class DiscountPerQuantityPromotion : Promotion
    {
        public DiscountPerQuantityPromotion(int quantity, int discountPercentage)
        {
            Quantity = quantity;
            DiscountPercentage = discountPercentage;
        }

        public int Quantity { get; init; }

        public double DiscountPercentage { get; init; }

        public override double Apply(Product product, int quantity)
        {
            return quantity % Quantity * product.Price +
                   quantity / Quantity * Quantity * (100.0 - DiscountPercentage) / 100.0 * product.Price;
        }
    }
}
