using FoodProject.Data;
using FoodProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FoodProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }



        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                name = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                name = "Lcd",
                stock = 75
            });
            cs.Add(new Class1()
            {
                name = "Usb Disk",
                stock = 220
            });

            return cs;
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResultx()
        {

            Context c = new Context();
            //return Json(FoodListMethod());
            return Json(c.Foods.ToList());
        }


        public List<FoodList> FoodListMethod()
        {
            List<FoodList> list = new List<FoodList>();
          using (var c =new Context())
            {
                list = c.Foods.Select(x => new FoodList
                {
                    Name = x.Name,
                    Stock =x.Stock,
                   



                }).ToList();
            };
            return list;

            
        }




        public IActionResult Statistics()
        {
            Context context = new Context();
            var toplamFood = context.Foods.Count();
            var toplamCategory = context.Categories.Count();
            var toplamMeyve = context.Foods.Where(x => x.CategoryID == 2).Count();
            var toplamSebze = context.Foods.Where(x => x.CategoryID == 1).Count();
            var toplamYiyecekAdedi = context.Foods.Sum(x => x.Stock);

            var enCokBulunanUrun = context.Foods.OrderByDescending(X => X.Stock).Select(y => y.Name).FirstOrDefault();
            var enAzBulunanUrun = context.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();

            var ortalamaFiyat = context.Foods.Average(x => x.Price).ToString("0.00");


            var enUcuzUrun=context.Foods.OrderBy(x => x.Price).Select(y => y.Name).FirstOrDefault();
            var enUcuzUrunFiyat = context.Foods.OrderBy(x => x.Price).Select(y => y.Price).FirstOrDefault();

            var enPahaliUrun = context.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            var enPahaliUrunFiyati = context.Foods.OrderByDescending(x => x.Price).Select(y => y.Price).FirstOrDefault();


            ViewBag.toplamFood = toplamFood;
            ViewBag.toplamCategory = toplamCategory;
            ViewBag.toplamMeyve = toplamMeyve;
            ViewBag.toplamSebze = toplamSebze;
            ViewBag.toplamYiyecekAdedi = toplamYiyecekAdedi;
            ViewBag.enCokBulunanUrun = enCokBulunanUrun;
            ViewBag.enAzBulunanUrun = enAzBulunanUrun;
            ViewBag.ortalamaFiyat = ortalamaFiyat;
            ViewBag.enUcuzUrun=enUcuzUrun;
            ViewBag.enUcuzUrunFiyat = enUcuzUrunFiyat;
            ViewBag.enPahaliUrun = enPahaliUrun;
            ViewBag.enPahaliUrunFiyati = enPahaliUrunFiyati;




            return View();
        }



}

}
