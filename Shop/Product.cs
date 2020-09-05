namespace ShopingZone.Shop
{
    public class Product
    {
        protected internal Product()
        {
        }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
    }
}