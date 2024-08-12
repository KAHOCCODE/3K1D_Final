using Microsoft.AspNetCore.Mvc;

namespace _3K1D_Final.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
