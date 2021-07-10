using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required,Display(Name ="Category Name")]
        public string Category_Name { get; set; }

    }
}