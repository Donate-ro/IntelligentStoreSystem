using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class Store
    {
        public IEnumerable<Product> Items { get; private set; }
        public Dictionary<Profession, IEnumerable<Product>> Map { get; private set; } = new Dictionary<Profession, IEnumerable<Product>>();

        public Store(Dictionary<Profession, IEnumerable<Product>> map, IEnumerable<Product> products)
        {
            Items = products;
            Map = map;
        }

    }
}
