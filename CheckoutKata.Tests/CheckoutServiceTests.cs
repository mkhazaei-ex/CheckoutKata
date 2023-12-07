namespace CheckoutKata.Tests
{
    [TestClass]
    public class CheckoutServiceTests
    {
        // Given I have selected to add an item to the basket Then the item should be added to the basket
        [TestMethod]
        public void TestAddingItem()
        {
            throw new NotImplementedException();
        }

        // Given items have been added to the basket Then the total cost of the basket should be calculated
        [TestMethod]
        public void TestCalculatingPriceAfterAItemMultipleTimesToTheBasket()
        {
            throw new NotImplementedException();
        }

        // Given I have added a multiple of 3 lots of item ‘B’ to the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3
        [TestMethod]
        public void TestFixedPricePerQuantityPromotion(int quantity, double expectedPrice)
        {
            throw new NotImplementedException();
        }

        // Given I have added a multiple of 2 lots of item ‘D’ to the basket Then a promotion of ‘25% off’ should be applied to every multiple of 2
        [TestMethod]
        public void TestDiscountPerQuantityPromotion(int quantity, double expectedPrice)
        {
            throw new NotImplementedException();
        }

    }
}