using Microsoft.AspNetCore.Mvc;

namespace _3K1D_Final.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }


    }
}
