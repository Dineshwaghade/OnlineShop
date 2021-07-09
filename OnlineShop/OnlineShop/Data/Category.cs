using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Category_Name { get; set; }
//        public virtual ICollection<SubCategory> Subcategories { get; set; }
    }
}