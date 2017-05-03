using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class IntellegentDiscountSystem
    {
        public IEnumerable<Product> Products { get; private set; }
        public Dictionary<ProductType, int> TypeDiscounts { get; set; } = new Dictionary<ProductType, int>();
        public Dictionary<Product, int> ProductDiscounts { get; set; } = new Dictionary<Product, int>();

        public IntellegentDiscountSystem(Dictionary<ProductType, int> typeDiscounts, Dictionary<Product, int> productDiscounts)
        {
            TypeDiscounts = typeDiscounts;
            ProductDiscounts = productDiscounts;
        }

        public List<Product> AddDiscounts(IEnumerable<Product> products)
        {
            List<Product> productsWithDiscounts = new List<Product>();
            int typeDiscount = 0;
            int productDiscount = 0;
            foreach (var product in products)
            {
                if (!TypeDiscounts.TryGetValue(product.ProductType, out typeDiscount) && (!ProductDiscounts.TryGetValue(product, out productDiscount)))
                    productsWithDiscounts.Add(new Product(product.ProductType, product.Cost));
                else
                    if (typeDiscount > productDiscount) productsWithDiscounts.Add(new ProductDiscount(product.ProductType, product.Cost, typeDiscount));
                else productsWithDiscounts.Add(new ProductDiscount(product.ProductType, product.Cost, productDiscount));
            }
            return productsWithDiscounts;
        }

    }
}
