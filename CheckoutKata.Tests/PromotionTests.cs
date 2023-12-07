using CheckoutKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class PromotionTests
    {
        [TestMethod]
        public void TestDiscountPerQuantityPromotion()
        {
            var promotion = new DiscountPerQuantityPromotion(2, 50);
            var result = promotion.Apply(100, 5);

            Assert.AreEqual(300, result); // 4 * 100 * 50% + 100
        }

        [TestMethod]
        public void TestFixedPricePerQuantityPromotion()
        {
            var promotion = new FixedPricePerQuantityPromotion(2, 150);
            var result = promotion.Apply(100, 5);

            Assert.AreEqual(400, result); // 2 * 150 + 100
        }
    }
}
