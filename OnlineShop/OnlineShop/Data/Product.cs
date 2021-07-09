using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Cover_PhotoUrl { get; set; }
        public Nullable<decimal> Price { get; set; }
        [ForeignKey("SubCategory")]
        public Nullable<int> SubCategory_id { get; set; }
        public virtual SubCategory SubCategory { get; set; }

    }
}