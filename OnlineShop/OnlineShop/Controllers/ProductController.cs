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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCategory()
        {
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
                    ViewBag.isSuccess = true;
                    ModelState.Clear();
                }
            }
            ViewBag.CategoryList = repo.CategoryList();
            return View();
        }
    }
}