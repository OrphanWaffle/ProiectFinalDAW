using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;
using ProiectFinalDAW.Data;

namespace ProiectFinalDAW.Repositories
{
    public class QuantityRepository : GenericRepository<Quantity>, IQuantityRepository
    {
        public QuantityRepository(Context C) : base(C)
        {

        }

        public Quantity GetbyName(string name)
        {
            return _table.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
