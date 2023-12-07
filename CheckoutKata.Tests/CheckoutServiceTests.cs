using CheckoutKata.Models;

namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutServiceTests
    {
        private IQueryable<Product> _products;
        public CheckoutServiceTests()
        {
            _products = new List<Product>()
                {
                    new Product("A", 10),
                    new Product("B", 15, new FixedPricePerQuantityPromotion(3, 40)),
                    new Product("C", 40),
                    new Product("D", 55, new DiscountPerQuantityPromotion(2, 25)),
                }.AsQueryable();

        }

        // Given I have selected to add an item to the checkout Then the item should be added to the checkout
        [TestMethod]
        public void TestAddingItem()
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("A", 3);

            Assert.AreEqual("Test", checkout.User);
            Assert.AreEqual(1, checkout.Items.Count());
            Assert.AreEqual(1, checkout.Items.Where(m => m.ProductSKU == "A").Count());
            Assert.AreEqual(3, checkout.Items.First(m => m.ProductSKU == "A").Quantity);
        }

        // Given Invalid SKU Then throw exception
        [TestMethod]
        public void TestAddingInvalidItem()
        {
            var checkout = new CheckoutService("Test", _products);
            Assert.ThrowsException<ArgumentException>(() => checkout.Add("E", 3), "provided SKU E is not valid.");
        }

        // Given one item have been added to the checkout Then the total cost of the checkout should be calculated
        [TestMethod]
        public void TestCalculatingPriceAfterAddingItemToTheBasket()
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("A", 3);

            Assert.AreEqual(1, checkout.Items.Count());
            Assert.AreEqual(30, checkout.Total); // 3 * 10
            Assert.AreEqual(0, checkout.Discount); // 0
        }

        // Given multiple items have been added to the checkout Then the total cost of the checkout should be calculated
        [TestMethod]
        public void TestCalculatingPriceAfterAddingMultipleItemsToTheBasket()
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("A", 3);
            checkout.Add("C", 2);

            Assert.AreEqual(2, checkout.Items.Count());
            Assert.AreEqual(110, checkout.Total); // 3 * 10 + 2 * 40
            Assert.AreEqual(0, checkout.Discount); // 0
        }

        // Given item have been added multiple times to the checkout Then the total cost of the checkout should be calculated
        [TestMethod]
        public void TestCalculatingPriceAfterAddingAItemMultipleTimesToTheBasket()
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("A", 3);
            checkout.Add("A", 2);

            Assert.AreEqual(1, checkout.Items.Count());
            Assert.AreEqual(50, checkout.Total); // 5 * 10
            Assert.AreEqual(0, checkout.Discount); // 0
        }



        // Given I have added a multiple of 3 lots of item ‘B’ to the checkout Then a promotion of ‘3 for 40’ should be applied to every multiple of 3
        [DataTestMethod]
        [DataRow(2, 30, 0, DisplayName = "2 Items")] // 2 * 15
        [DataRow(3, 40, 5, DisplayName = "3 Items")] // 40 | 3 * 15 - X
        [DataRow(6, 80, 10, DisplayName = "6 Items")] // 2 * 40 | 6 * 15 - X
        [DataRow(7, 95, 10, DisplayName = "7 Items")] // 2 * 40 + 15 | 7 * 15 - X
        public void TestFixedPricePerQuantityPromotion(int quantity, double expectedPrice, double expectedDiscount)
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("B", quantity);

            Assert.AreEqual(1, checkout.Items.Count());
            Assert.AreEqual(expectedPrice, checkout.Total);
            Assert.AreEqual(expectedDiscount, checkout.Discount);
        }

        // Given I have added a multiple of 2 lots of item ‘D’ to the checkout Then a promotion of ‘25% off’ should be applied to every multiple of 2
        [DataTestMethod]
        [DataRow(1, 55, 0, DisplayName = "1 Items")]
        [DataRow(2, 82.5, 27.5, DisplayName = "2 Items")] // 2 * 55 * .75 | 2 * 55 - X
        [DataRow(4, 165, 55, DisplayName = "4 Items")] // 4 * 55 * .75 | 4 * 55 - X
        [DataRow(5, 220, 55, DisplayName = "5 Items")] // 4 * 55 * .75 + 55 | 5 * 55 - X
        public void TestDiscountPerQuantityPromotion(int quantity, double expectedPrice, double expectedDiscount)
        {
            var checkout = new CheckoutService("Test", _products);
            checkout.Add("D", quantity);

            Assert.AreEqual(1, checkout.Items.Count());
            Assert.AreEqual(expectedPrice, checkout.Total);
            Assert.AreEqual(expectedDiscount, checkout.Discount);
        }
    }
}