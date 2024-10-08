﻿using _3K1D_Final.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3K1D_Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagementMovieController : Controller
    {
        private readonly QlrapPhimContext _context;

        public ManagementMovieController(QlrapPhimContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var today =DateOnly.FromDateTime(DateTime.Now);
            var movies = _context.Phims
                .Where(p => p.NgayKhoiChieu <= today && p.NgayKetThuc >=today)
                .ToList();
            return View(movies);
        }
        public IActionResult MoviesEnd()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var movies = _context.Phims
                .Where(p => p.NgayKetThuc < today)
                .ToList();
            return View(movies);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Phim phim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phim);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(phim);
        }
    }
}
