namespace ShopingZone.Shop
{
    public class AvailableProducts : Product
    {
        protected internal AvailableProducts()
        {
        }

        public AvailableProducts(string name, decimal price) : base(name, price)
        {
        }
    }
}