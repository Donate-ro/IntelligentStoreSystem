using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentStoreSystem
{
    class IntellegentSystem
    {
        public Dictionary<Profession, IEnumerable<Product>> map { get; set; } = new Dictionary<Profession, IEnumerable<Product>>();

        public IntellegentSystem(IEnumerable<Product> products)
        {
            map = CreateMap(products);
        }

        Dictionary<Profession, IEnumerable<Product>> CreateMap(IEnumerable<Product> Items)
        {
            Dictionary<Profession, IEnumerable<Product>> map = new Dictionary<Profession, IEnumerable<Product>>();
            map.Add(Profession.housewife, Items.Where(p=> p.ProductType!=ProductType.SetOfBricks && p.ProductType != ProductType.Ball));
            map.Add(Profession.builder, Items.Where(p => p.ProductType != ProductType.Bananas && p.ProductType != ProductType.Ball));
            map.Add(Profession.sportsman, Items.Where(p => p.ProductType != ProductType.SetOfBricks && p.ProductType != ProductType.Oven));
            map.Add(Profession.cook, Items.Where(p => p.ProductType != ProductType.SetOfBricks && p.ProductType != ProductType.Ball));
            return map;
        }
        
    }
}
