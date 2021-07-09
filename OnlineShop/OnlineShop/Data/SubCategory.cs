using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Data
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string SubCategory_Name { get; set; }
        [ForeignKey("Category")]
        public Nullable<int> Category_id { get; set; }
        public virtual Category Category { get; set; }

    }
}