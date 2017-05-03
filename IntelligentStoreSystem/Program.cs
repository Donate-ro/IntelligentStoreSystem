using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Buyer> persons = new List<Buyer>();
            persons.Add(new Buyer(1, "Mary", "Smith", Profession.housewife, 2000));
            persons.Add(new Buyer(2, "Igor", "Rox", Profession.sportsman, 3000));

            List<Product> products = new List<Product>();
            products.Add(new Product(ProductType.Ball, 200));
            products.Add(new Product(ProductType.Bananas, 2100));
            products.Add(new Product(ProductType.Oven, 300));

            Dictionary<Product, int> productDiscounts = new Dictionary<Product, int>();
            productDiscounts.Add(products.ElementAt(1), 10);

            Dictionary<ProductType, int> typeDiscounts = new Dictionary<ProductType, int>();
            typeDiscounts.Add(products.ElementAt(2).ProductType, 30);

            Store shop = new Store(new IntellegentSystem(products).map, new IntellegentDiscountSystem(typeDiscounts, productDiscounts).AddDiscounts(products));
            AnalyzeBuyers(shop, persons);
        }

        static bool CheckCost(Product item, double Amount)
        {
            ProductDiscount discount = item as ProductDiscount;
            if (discount == null)
            {
                if (item.Cost < Amount) return true;
            }
            else if ((discount.Cost - discount.Cost * discount.Discount / 100) < Amount) return true;
            return false;
        }

        static bool CheckBuyer(Product item, Buyer buyer, Store store)
        {
            foreach (var compare in store.Map)
            {
                if (compare.Key == buyer.Profession)
                    foreach (var product in compare.Value)
                    {
                        if (item.ProductType == product.ProductType)
                        {
                            if (CheckCost(item, buyer.Amount)) return true;
                        }
                    }
            }
            return false;
        }

        static void Print(Product item)
        {
            ProductDiscount discount = item as ProductDiscount;
            if (discount != null)
                Console.WriteLine(discount.ProductType + " With Cost: " + discount.Cost + " and discount: " + discount.Discount);
            else Console.WriteLine(item.ProductType + " With Cost: " + item.Cost);
        }

        static void AnalyzeBuyers(Store store, List<Buyer> Buyers)
        {
            foreach (var buyer in Buyers)
            {
                Console.WriteLine(buyer.FirstName + " " + buyer.LastName + " with amount of money - " + buyer.Amount + " can buy:");
                if (store.Map.ContainsKey(buyer.Profession))
                {
                    foreach (var item in store.Items)
                    {
                        if (CheckBuyer(item, buyer, store))
                        {
                            Print(item);
                        }
                    }
                }
                else
                {
                    foreach (var item in store.Items)
                    {
                        if (CheckCost(item, buyer.Amount))
                        {
                            Print(item);
                        }
                    }
                }
            }
        }
    }
}
