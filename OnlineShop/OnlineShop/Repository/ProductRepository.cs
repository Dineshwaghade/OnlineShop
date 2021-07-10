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
        public int AddNewSubCategory(SubCategoryModel model)
        {
            SubCategory subcategory = new SubCategory()
            {
                Category_id = model.Category_id,
                SubCategory_Name=model.SubCategory_Name
            };
            db.SubCategories.Add(subcategory);
            db.SaveChanges();
            return subcategory.Id;
        }
        public List<SubCategoryModel> SubCategoryList()
        {
            var CList = db.SubCategories
                .Select(x => new SubCategoryModel()
                {
                    Id = x.Id,
                    Category_id = x.Category_id,
                    SubCategory_Name=x.SubCategory_Name
                })
                .ToList();
            return CList;
        }
        public bool RemoveSubCategory(int id)
        {
            var data = db.SubCategories.Find(id);
            if (data != null)
            {
                db.SubCategories.Remove(data);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public SubCategoryModel GetSubCategoryById(int id)
        {
            var data = db.SubCategories.Select(x => new SubCategoryModel()
            {
                Id = x.Id,
                Category_id = x.Category_id,
                SubCategory_Name=x.SubCategory_Name
            })
            .Where(x => id == x.Id)
            .FirstOrDefault();
            return data;
        }
        public bool UpdateSubCategory(SubCategoryModel model)
        {
            SubCategory scat = new SubCategory()
            {
                Id = model.Id,
                Category_id = model.Category_id,
                SubCategory_Name=model.SubCategory_Name
            };
            db.Entry(scat).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

    }
}