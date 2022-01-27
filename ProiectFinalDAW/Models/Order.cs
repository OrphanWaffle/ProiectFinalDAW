using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models.Base;

namespace ProiectFinalDAW.Models
{
    public enum order_status 
    {
        Received,Processing,Shipping
    }
    public class Order:BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public order_status Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
