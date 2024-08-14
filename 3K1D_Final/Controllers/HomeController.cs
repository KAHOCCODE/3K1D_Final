using _3K1D_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace _3K1D_Final.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        //truyền dữ liệu data phim từ model phim vào _Home.cshtml
        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { });
        }



        public IActionResult Detail()
        {
            var id = Request.Query["id"].ToString();
            using (var db = new QlrapPhimContext())
            {
                var phim = db.Phims
                    .Include(p => p.IdTheLoais)
                    .FirstOrDefault(p => p.IdPhim == id);



                return View(phim);
            }
        }
    }

    //lấy dữu liệu ApPhich từ database dựa vào id chuyển đổi thành file ảnh và truyền qua detail bằng cách đơn giản nhất












}
