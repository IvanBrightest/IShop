using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Customer : IdentityUser
    {
        public string Address { get; set; }
        public string FIO { get; set; }
    }
}
