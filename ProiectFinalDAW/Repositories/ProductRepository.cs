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
    }
}
