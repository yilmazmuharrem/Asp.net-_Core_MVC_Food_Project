using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodProject.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        [AllowAnonymous]

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public async  Task<IActionResult> Index(Admin admin)
        {
            var DataValue = context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (DataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };
                var userIdentity=new ClaimsIdentity(claims,"Login");

                ClaimsPrincipal pricipal =new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(pricipal);
                 return RedirectToAction("Index", "Category");
               // return Redirect("/Category/Index");
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }
    }
}
