using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;
using ProiectFinalDAW.Data;
using Microsoft.EntityFrameworkCore;

namespace ProiectFinalDAW.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        public ProductRepository (Context C):base(C)
        {

        }

        public Product GetbyProduct(string name)
        {
            return _table.Include(x => x.Category).Include(x => x.Quantity).FirstOrDefault(x => x.Title.Equals(name));
        }

        public Product ProductPriceRange(int min, int max)
        {
            var result = from x in _table
                         where min <= int.Parse(x.Price) && int.Parse(x.Price) <= max
                         select x;

            return result.FirstOrDefault();
        }
        public ICollection<Tuple<int , string>> ProductsByCategory ()
        {
            var result = from x in _context.Products
                         join y in _context.Categories
                         on x.CategoryId equals y.Id
                         group y by y.Name into g
                         select new
                         {
                             Category = g.Count(),
                             g.Key
                         };
            var list = new List<Tuple<int, string>>();
            foreach (var i in result)
            {
                list.Add(new Tuple<int, string>(i.Category, i.Key));
            }
            return list;
        }
    }
}
