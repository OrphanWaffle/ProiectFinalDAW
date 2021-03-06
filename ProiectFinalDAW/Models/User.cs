using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProiectFinalDAW.Models.Base;

namespace ProiectFinalDAW.Models
{
    public enum role { Admin,User }
    public class User : BaseEntity
    {
        public role Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone_number { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
