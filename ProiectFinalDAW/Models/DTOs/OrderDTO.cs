using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectFinalDAW.Models.DTOs
{
    public class OrderDTO
    {
        public ICollection<ProductDTO> Products { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
