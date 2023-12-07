using CheckoutKata.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class OrderItemTests
    {
        [TestMethod]
        public void TestCalculatingPrice()
        {
            var product = new Product("A", 100);
            var orderItem = new OrderItem(product, 5);

            Assert.AreEqual(500, orderItem.Amount);
            Assert.AreEqual(0, orderItem.Discount);
        }

        [TestMethod]
        public void TestCalculatingPriceWithPromotion()
        {
            var promotion = new Mock<IPromotion>();
            promotion.Setup(m => m.Apply(100, 5)).Returns(400);
            var product = new Product("A", 100, promotion.Object);
            var orderItem = new OrderItem(product, 5);

            Assert.AreEqual(400, orderItem.Amount);
            Assert.AreEqual(100, orderItem.Discount);
            promotion.Verify(m => m.Apply(100, 5), Times.Once());
        }

        [TestMethod]
        public void TestCalculatingPriceWithPromotionThatReturnBiggerValue()
        {
            var promotion = new Mock<IPromotion>();
            promotion.Setup(m => m.Apply(100, 5)).Returns(600);
            var product = new Product("A", 100, promotion.Object);
            var orderItem = new OrderItem(product, 5);

            Assert.AreEqual(500, orderItem.Amount);
            Assert.AreEqual(0, orderItem.Discount);
            promotion.Verify(m => m.Apply(100, 5), Times.Once());
        }
    }
}
