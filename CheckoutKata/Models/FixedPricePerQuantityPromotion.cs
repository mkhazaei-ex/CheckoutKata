using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class FixedPricePerQuantityPromotion : Promotion
    {
        public FixedPricePerQuantityPromotion(int quantity, int fixedPrice)
        {
            Quantity = quantity;
            FixedPrice = fixedPrice;
        }

        public int Quantity { get; init; }

        public int FixedPrice { get; init; }

        public override double Apply(Product product, int quantity)
        {
            return quantity % Quantity * product.Price +
                   quantity / Quantity * FixedPrice;
        }
    }
}
