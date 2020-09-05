using System;
using System.Collections.Generic;
using ShopingZone.Shop;

namespace ShopingZone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Shopping Zone!");
            Order order = new Order();
            AvailableProducts A = new AvailableProducts("A", 50);
            order.addProduct(A, 5);
            // 250 + 3*30
            AvailableProducts B = new AvailableProducts("B", 30);
            order.addProduct(B, 3);
            AvailableProducts C = new AvailableProducts("C", 20);
            order.addProduct(C, 4);
            AvailableProducts D = new AvailableProducts("D", 15);
            order.addProduct(D, 3);
            Promotion fixedPriceOnMultipleItem1 = new NumberOfProductInFixedCost("Buy 3A at fixed Price 130", new List<Product> { A }, 130, 3);
            order.AddDiscount(fixedPriceOnMultipleItem1);
            Promotion fixedPriceOnMultipleItem2 = new NumberOfProductInFixedCost("Buy 2B at fixed Price 45", new List<Product> { B }, 45, 2);
            order.AddDiscount(fixedPriceOnMultipleItem2);
           Promotion fixedPrice = new BuySKU1_SKU2FixedPrice("Buy SKU1 & SKU2 at fixed Price", new List<Product> { C }, new List<Product> { D }, 30);
           order.AddDiscount(fixedPrice);
            foreach (var item in order.ItemOnCart)
            {
                Console.WriteLine("Product- "+ item.Product.Name + " purchased at price of " + item.DiscountAmount );
            }
            Console.ReadLine();
        }
    }
}
