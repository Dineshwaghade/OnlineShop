using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class SubCategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="Sub Category Name")]
        public string SubCategory_Name { get; set; }
        [ForeignKey("Category"),Display(Name ="Category Name")]
        [Required]
        public Nullable<int> Category_id { get; set; }
        public virtual CategoryModel Category { get; set; }

    }
}