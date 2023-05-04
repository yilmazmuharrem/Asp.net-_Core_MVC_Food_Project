using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {

       public IViewComponentResult Invoke()
        {
            CategoryRepository category =new CategoryRepository();
            var categoryList = category.List();

            return View(categoryList);
        }






    }
}
