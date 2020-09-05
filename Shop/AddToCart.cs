
using System.Collections.Generic;
using System.Linq;

namespace ShopingZone.Shop
{
    public class AddToCart
    {
        private IList<Promotion> _Discounts = new List<Promotion>();
        
        public virtual Order Order { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual int Quantity { get; private set; }
        public virtual decimal DiscountAmount { get; set; }
        public virtual decimal Subtotal
        {
            get { return (Product.Price * Quantity) - DiscountAmount; }
        }
        public virtual IList<Promotion> _promotion
        {
            get { return _Discounts.ToList().AsReadOnly(); }
        }

        protected internal AddToCart() { }

        public AddToCart(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public virtual void AddDiscount(Promotion promotion)
        {   
            _Discounts.Add(promotion);
        }


    }
}