using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class ProductDiscount: Product
    {
        public int Discount { get; set; }

        public ProductDiscount(ProductType product, double cost, int discount) : base(product, cost)
        {
            Discount = discount;
        }
    }
}
