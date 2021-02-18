using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }
        public Brand Parent { get; set; }
        public List<Brand> Childrens { get; set; }
    }
}