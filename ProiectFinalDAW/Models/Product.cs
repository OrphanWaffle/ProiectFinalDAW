using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models.Base;

namespace ProiectFinalDAW.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Activate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid QuantityId { get; set; }
        public virtual Quantity Quantity { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
