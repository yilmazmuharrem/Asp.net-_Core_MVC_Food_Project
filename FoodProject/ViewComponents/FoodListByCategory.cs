using FoodProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodProject.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {



        public IViewComponentResult Invoke(int id)
        {

        
            FoodRepository foodRepository = new FoodRepository();
            var list = foodRepository.ListC(x=>x.CategoryID==id);

            return View(list);



        }
    }
}
