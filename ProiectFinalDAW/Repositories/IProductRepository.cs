using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;

namespace ProiectFinalDAW.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Product GetbyProduct(string name);
        Product ProductPriceRange(int min, int max);
        ICollection<Tuple<int, string>> ProductsByCategory();
    }
}
