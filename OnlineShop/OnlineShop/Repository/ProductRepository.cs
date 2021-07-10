using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Repository
{
    public class ProductRepository
    {
        DataContext db = new DataContext();
        public int AddNewCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Category_Name =model.Category_Name
            };
            db.Categories.Add(category);
            db.SaveChanges();
            return category.Id;
        }
        public List<CategoryModel> CategoryList()
        {
            var CList = db.Categories
                .Select(x=> new CategoryModel()
                {
                    Id=x.Id,
                    Category_Name=x.Category_Name
                })
                .ToList();
            return CList;
        }
    }
}