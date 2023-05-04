using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.ViewComponents
{
    public class FoodGetList:ViewComponent
    {

        
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var list = foodRepository.List();

            return View(list);


            
        }



    }
}
