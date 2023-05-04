using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository category = new CategoryRepository();


        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(category.ListC(x => x.CategoryName == p));
            }
            return View(category.List());
        }


        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category cat)
        {


            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            category.Add(cat);

            return RedirectToAction("Index");
        }


        public IActionResult CategoryGet(int id)
        {
            var _cat = category.Get(id);

            Category categoryDetails = new Category()
            {
                CategoryName = _cat.CategoryName,
                CategoryDescription = _cat.CategoryDescription,
                CategoryId = _cat.CategoryId
            };
            return View(categoryDetails);
        }



        [HttpPost]
        public IActionResult CategoryUpdate(Category categorytemp)
        {
            var _category= category.Get(categorytemp.CategoryId);
            _category.CategoryName = categorytemp.CategoryName;
            _category.CategoryDescription = categorytemp.CategoryDescription;
            _category.Status = true;
            category.Update(_category);
            return RedirectToAction("Index");
        }


        public IActionResult CategoryDelete(int id)
        {
            var _category = category.Get(id);
            _category.Status = false;
            category.Update(_category);
            return RedirectToAction("Index");
        }

    }
}
