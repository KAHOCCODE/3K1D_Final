using _3K1D_Final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _3K1D_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeAdminController : Controller
    {
        QlrapPhimContext db = new QlrapPhimContext();

        [Route("Admin/HomeAdmin")]
        [Route("Admin/")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin/Customer/CustomerLists")]
        public IActionResult CustomerLists()
        {
            var CUSTOMERS = db.KhachHangs.ToList();
            return View(CUSTOMERS);
        }

        [Route("Admin/Customer/Create")]
        [HttpGet]
        public IActionResult CustomerCreate()
        {
            return View();
        }

        [Route("Admin/Customer/Create")]
        [HttpPost]
        public IActionResult CustomerCreate(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("CustomerLists");
            }
            return View(kh);
        }

        [Route("Admin/Customer/Edit/{id}")]
        [HttpGet]
        public IActionResult CustomerEdit(string id)
        {
            var customer = db.KhachHangs.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [Route("Admin/Customer/Edit/{id}")]
        [HttpPost]
        public IActionResult CustomerEdit(string id, KhachHang updatedCustomer)
        {
            var customer = db.KhachHangs.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                customer.HoTen = updatedCustomer.HoTen;
                customer.NgaySinh = updatedCustomer.NgaySinh;
                customer.DiaChi = updatedCustomer.DiaChi;
                customer.Sdt = updatedCustomer.Sdt;
                customer.Cccd = updatedCustomer.Cccd;
                // Update other properties as needed

                db.SaveChanges();
                return RedirectToAction("CustomerLists");
            }

            return View(updatedCustomer);
        }
    }
}
