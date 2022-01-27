using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;

namespace ProiectFinalDAW.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        User GetByUsername(string name);
        User GetAllOrders(string name);
    }
}
