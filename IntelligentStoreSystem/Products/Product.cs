using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class Product
    {
        public ProductType ProductType { get; private set; }
        public double Cost { get; set; }

        public Product(ProductType product, double cost)
        {
            ProductType = product;
            Cost = cost;
        }
    }
}
