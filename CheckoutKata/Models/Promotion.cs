using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Models
{
    public abstract class Promotion
    {

        public Promotion() { }

        public int Id { get; set; }

        public abstract double Apply(Product product, int quantity);

    }
}
