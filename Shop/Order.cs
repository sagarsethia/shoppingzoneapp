using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopingZone.Shop
{
    public class Order
    {
        private IList<AddToCart> _addToCart = new List<AddToCart>();
        private IList<Promotion> _discounts = new List<Promotion>();

        protected internal Order() { }


        public AddToCart addProduct(Product product, int quantity)
        {
            AddToCart addedProducts = new AddToCart(this, product, quantity);
            _addToCart.Add(addedProducts);
            return addedProducts;
        }

        public void AddDiscount(Promotion promotion)
        {
            promotion.Order = this;
            promotion.ApplyDiscount();
            _discounts.Add(promotion);
        }

        public virtual decimal GrossTotal
        {
            get
            {
                return _addToCart
                    .Sum(x => x.Product.Price * x.Quantity);
            }
        }
        public IList<AddToCart> ItemOnCart
        {
            get
            {
                return _addToCart;
            }
        }
    }
}