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
        public bool RemoveCategory(int id)
        {
            var data = db.Categories.Find(id);
            if(data!=null)
            {
                db.Categories.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public CategoryModel GetCategoryById(int id)
        {
            var data = db.Categories.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Category_Name = x.Category_Name
            })
            .Where(x=>id==x.Id)
            .FirstOrDefault();
            return data;
        }
        public bool UpdateCategory(CategoryModel model)
        {
            Category cat = new Category()
            {
                Id=model.Id,
                Category_Name=model.Category_Name
            };
            db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}