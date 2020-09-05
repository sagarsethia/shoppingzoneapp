using NUnit.Framework;

namespace ShopingZone
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanLoadItemToCart()
        {
            Order order = new Order();
            AvailableProducts A = new AvailableProducts("A", 50);
            order.addProduct(A, 5);
            AvailableProducts B = new AvailableProducts("B", 30);
            order.addProduct(B, 3);
            Assert.AreEqual(order.Quantiy,2).;
        }
    }
}