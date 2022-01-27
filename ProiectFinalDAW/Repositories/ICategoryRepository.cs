using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;

namespace ProiectFinalDAW.Repositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Category GetByCategory(string name);
    }
}
