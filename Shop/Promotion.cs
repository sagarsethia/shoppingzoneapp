namespace ShopingZone.Shop
{
    public abstract class Promotion
    {
        protected internal Promotion()
        {
        }

        public Promotion(string name)
        {
            Name = name;
        }
        public abstract Order ApplyDiscount();
        public virtual Order Order { get; set; }
        public virtual string Name { get; private set; }

    }
}