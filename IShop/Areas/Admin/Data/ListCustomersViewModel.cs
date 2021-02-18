using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Areas.Admin.Data
{
    public class ListCustomersViewModel
    {
        public string Id { get; set; }
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
