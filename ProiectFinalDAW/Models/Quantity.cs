using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models.Base;

namespace ProiectFinalDAW.Models
{
    public class Quantity:BaseEntity
    {
        public virtual Product Product { get; set; }
        public string Name { get; set; } 
        public int Cantitate { get; set; }
    }
}
