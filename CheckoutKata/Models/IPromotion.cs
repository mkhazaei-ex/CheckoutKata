using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public interface IPromotion
    {
        public abstract double Apply(double unitPrice, int quantity);
    }
}
