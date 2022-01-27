using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models;
using ProiectFinalDAW.Data;

namespace ProiectFinalDAW.Repositories
{
    public class OrderDetailRepository:GenericRepository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository (Context C):base(C)
        {

        }
    }
}
