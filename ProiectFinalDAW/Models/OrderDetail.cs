﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models.Base;

namespace ProiectFinalDAW.Models
{
    public class OrderDetail:BaseEntity
    {
        public virtual Product Product { get; set; }

        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }
    }
}
