using System.Collections.Generic;
using System.Linq;

namespace ShopingZone.Shop
{

    public class BuySKU1_SKU2FixedPrice : Promotion
    {

        public virtual IList<Product> ApplicableProduct1 { get; set; }
        public virtual IList<Product> ApplicableProduct2 { get; set; }

        public decimal fixedPrice { get; set; }

        public BuySKU1_SKU2FixedPrice(string name) : base(name)
        {
        }

        protected internal BuySKU1_SKU2FixedPrice()
        {
        }

        public BuySKU1_SKU2FixedPrice(string name, IList<Product> product1, IList<Product> product2, decimal _fixedPrice)
        : base(name)
        {
            ApplicableProduct1 = product1;
            ApplicableProduct2 = product2;
            fixedPrice = _fixedPrice;

        }

        public override Order ApplyDiscount()
        {
            int product1Quantity = 0;
            int product2Quantity = 0;
           foreach (AddToCart Item in Order.ItemOnCart)
            {
                if (ApplicableProduct1.Contains(Item.Product))
                {
                    product1Quantity = Item.Quantity;
                }
                if (ApplicableProduct2.Contains(Item.Product))
                {
                    product2Quantity = Item.Quantity;
                }
                if (product1Quantity > 0 && product2Quantity > 0)
                {
                    if (product1Quantity > product2Quantity)
                    {
                        // product1Quantity = 17
                        // product2Quantity = 14
                        var extraItem = product1Quantity - product2Quantity;
                        Item.DiscountAmount = (Item.Product.Price * extraItem) + (fixedPrice * product2Quantity);
                        Item.AddDiscount(this);
                    }

                    if (product1Quantity < product2Quantity)
                    {
                        // product1Quantity = 5
                        // product2Quantity = 8 
                        var extraItem = product2Quantity - product1Quantity;
                        Item.DiscountAmount = (Item.Product.Price * extraItem) + (fixedPrice * product1Quantity);
                        Item.AddDiscount(this);
                    }
                    if (product1Quantity == product2Quantity)
                    {
                        Item.DiscountAmount += product1Quantity * fixedPrice;
                        Item.AddDiscount(this);

                    }
                }

            }
            return Order;
        }

    }
}