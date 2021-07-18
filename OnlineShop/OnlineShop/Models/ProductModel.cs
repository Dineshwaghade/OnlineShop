using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="Product Name")]
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public string Cover_PhotoUrl { get; set; }
        public HttpPostedFileBase Cover_Image { get; set; }
        public Nullable<decimal> Price { get; set; }
        [Display(Name ="Category")]
        public Nullable<int> Category_id { get; set; }
        [Required, ForeignKey("SubCategory")]
        [Display(Name = "SubCategory")]
        public Nullable<int> SubCategory_id { get; set; }
        public virtual SubCategoryModel SubCategory { get; set; }
        
    }
}