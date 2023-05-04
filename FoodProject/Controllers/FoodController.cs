using FoodProject.Data.Models;
using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace FoodProject.Controllers
{
    public class FoodController : Controller
    {

        FoodRepository foodRepository = new FoodRepository();
        Context context = new Context();
        public IActionResult Index(int page=1)
        {
          

            return View(foodRepository.List("Category").ToPagedList(page,3));
        }







        public IActionResult Delete(int id)
        {
            foodRepository.Delete(new Food { FoodID = id });
            return RedirectToAction("Index");
        }
//LİSTBOX YAZMA KODU

        [HttpGet]
        public IActionResult AddFood()
        {

            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.data = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food _food)
        {
            foodRepository.Add(_food);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult FoodGet(int id) { 

              var _food = foodRepository.Get(id);
        
            List<SelectListItem> values = (from y in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString()
                                           }).ToList();


            ViewBag.data = values;




            Food tempFood = new Food()
            {
                FoodID= _food.FoodID,
                Name = _food.Name,
                Price = _food.Price,
                Stock = _food.Stock,
                Description = _food.Description,
                ImageURL = _food.ImageURL,
                CategoryID = _food.CategoryID,


            };
            return View(tempFood);
        }

        [HttpPost]
        public IActionResult FoodUpdate(Food food)
        {
            var _food = foodRepository.Get(food.FoodID);
            _food.Name=food.Name;
            _food.Stock = food.Stock;
            _food.Description = food.Description;
            _food.ImageURL = food.ImageURL;
            _food.CategoryID = food.CategoryID;
            _food.Price = food.Price;

            foodRepository.Update(_food);

            return RedirectToAction("Index");
        }





























        // [HttpDelete]
        /*  public IActionResult DeleteFood(int p)
          {


            // var deneme = foodRepository.Get(p);
            //foodRepository.Delete(new Food { FoodID=p});

              foodRepository.Delete(p);
              return RedirectToAction("Index");
          }*/


        //[HttpPost]
        //public IActionResult sil(int p)
        //{


        //}


    }
}







