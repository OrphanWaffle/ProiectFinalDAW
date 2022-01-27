using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinalDAW.Models.DTOs
{
    public class AddProductDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public bool Activate { get; set; }
        public string CategoryName { get; set; }
        public string QuantityName { get; set; }
        public int Cantitate { get; set; }
        //public virtual Quantity Quantity { get; set; }
        //public Category Category { get; set; }
    }
}
