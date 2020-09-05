
using System.Collections.Generic;

namespace ShopingZone.Shop
{
    public class NumberOfProductInFixedCost : Promotion
    {
          public virtual IList<Product> ApplicableProduct { get; set; }
          public decimal fixedPrice { get; set; }

          public int quantity { get; set; }

        public NumberOfProductInFixedCost()
        {
        }
         public NumberOfProductInFixedCost(string name, IList<Product> product, decimal _fixedPrice, int _quantity)
        {
           ApplicableProduct = product;
           fixedPrice= _fixedPrice;
           quantity = _quantity;
        }

        public override Order ApplyDiscount()
        { 
             foreach (AddToCart Item in Order.ItemOnCart){
               //  check quantity is more than applicable promotion quantity
                if (Item.Quantity > quantity && ApplicableProduct[0].Name == Item.Product.Name)
                {
                  var extraQuantity = Item.Quantity % quantity;
                  var discountedRate = fixedPrice*(Item.Quantity / quantity);
                  var totalCost = (Item.Product.Price * extraQuantity) + discountedRate; 
                  Item.DiscountAmount = totalCost;
                  Item.AddDiscount(this);
                }
             }
            return Order;
        }
    }
}