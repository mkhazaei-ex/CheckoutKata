using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public class FixedPricePerQuantityPromotion : IPromotion
    {
        public FixedPricePerQuantityPromotion(int quantity, int fixedPrice)
        {
            Quantity = quantity;
            FixedPrice = fixedPrice;
        }

        public int Quantity { get; init; }

        public int FixedPrice { get; init; }

        public double Apply(double unitPrice, int quantity)
        {
            return quantity % Quantity * unitPrice +
                   quantity / Quantity * FixedPrice;
        }
    }
}
