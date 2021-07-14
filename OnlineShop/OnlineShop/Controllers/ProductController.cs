using OnlineShop.Models;
using OnlineShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository repo = new ProductRepository();
        public ActionResult GetSubCategoryListByCid(int cid)
        { DataContext db = new DataContext();
            var data = db.SubCategories.Where(x => x.Category_id == cid).ToList();
            ViewBag.sclist = new SelectList(data, "Id", "SubCategory_Name");
            return PartialView("_StatePartialView");
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //      -------------- Category ------------
        public ActionResult AddCategory()
        {
            if(TempData["delete"]!=null)
            {
                ViewBag.isDeleteSuccess = TempData["delete"];
            }
            ViewBag.CategoryList = repo.CategoryList();
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            if(ModelState.IsValid)
            {
                var result = repo.AddNewCategory(model);
                if (result > 0)
                {
                    ViewBag.isAddedSuccess = true;
                    ModelState.Clear();
                }
            }
            ViewBag.CategoryList = repo.CategoryList();
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            TempData["delete"]= repo.RemoveCategory(id);
            TempData.Keep();
            return RedirectToAction("AddCategory");
        }
        public ActionResult EditCategory(int id)
        {
            ViewBag.CategoryList = repo.CategoryList();
            var data = repo.GetCategoryById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditCategory(CategoryModel model)
        {

            if(ModelState.IsValid)
            {
               ViewBag.isUpdated= repo.UpdateCategory(model);
            }
            return RedirectToAction("AddCategory");
        }
        //      -------------- End Category ------------
        //      -------------- Start sub Category ------------
        public ActionResult AddSubCategory()
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
            if (TempData["delete"] != null)
            {
                ViewBag.isDeleteSuccess = TempData["delete"];
            }
            ViewBag.CategoryList = repo.SubCategoryList();
            return View();
        }
        [HttpPost]
        public ActionResult AddSubCategory(SubCategoryModel model)
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");

            if (ModelState.IsValid)
            {
                var result = repo.AddNewSubCategory(model);
                if (result > 0)
                {
                    ViewBag.isAddedSuccess = true;
                    ModelState.Clear();
                }
            }
            ViewBag.CategoryList = repo.SubCategoryList();
            return View();
        }
        public ActionResult EditSubCategory(int id)
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
            ViewBag.CategoryList = repo.SubCategoryList();
            var data = repo.GetSubCategoryById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult EditSubCategory(SubCategoryModel model)
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
            if (ModelState.IsValid)
            {
                ViewBag.isUpdated = repo.UpdateSubCategory(model);
            }
            return RedirectToAction("AddSubCategory");
        }
        public ActionResult DeleteSubCategory(int id)
        {
            TempData["delete"] = repo.RemoveSubCategory(id);
            TempData.Keep();
            return RedirectToAction("AddSubCategory");
        }
        //      -------------- End sub Category ------------
        //      -------------- start product ------------

        public ActionResult AddProduct()
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
//            ViewBag.sclist = new SelectList(repo.SubCategoryList(), "Id", "SubCategory_Name");
            if (TempData["delete"] != null)
            {
                ViewBag.isDeleteSuccess = TempData["delete"];
            }
            ViewBag.productList = repo.ProductList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
            ViewBag.sclist = new SelectList(repo.SubCategoryList(), "Id", "SubCategory_Name");
            
            if (ModelState.IsValid)
            {
                var result = repo.AddNewProduct(model);
                if (result > 0)
                {
                    ViewBag.isAddedSuccess = true;
                    ModelState.Clear();
                }
            }
            ViewBag.productList = repo.ProductList();
            return View();
        }
        //public ActionResult EditSubCategory(int id)
        //{
        //    ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
        //    ViewBag.CategoryList = repo.SubCategoryList();
        //    var data = repo.GetSubCategoryById(id);
        //    return View(data);
        //}
        //[HttpPost]
        //public ActionResult EditSubCategory(SubCategoryModel model)
        //{
        //    ViewBag.clist = new SelectList(repo.CategoryList(), "Id", "Category_Name");
        //    if (ModelState.IsValid)
        //    {
        //        ViewBag.isUpdated = repo.UpdateSubCategory(model);
        //    }
        //    return RedirectToAction("AddSubCategory");
        //}
        //public ActionResult DeleteSubCategory(int id)
        //{
        //    TempData["delete"] = repo.RemoveSubCategory(id);
        //    TempData.Keep();
        //    return RedirectToAction("AddSubCategory");
        //}
        //      -------------- End sub Category ------------
        //      -------------- start product ------------
    }
}