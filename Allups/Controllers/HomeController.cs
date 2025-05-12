using System.Diagnostics;
using Allups.DataAccessLayer.DataContext;
using Allups.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Allups.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;


        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Products = _appDbContext.Products
                .Include(p => p.Category)
                .ToList(),
                Categories = _appDbContext.Categories.ToList(),
            };
            ViewData["Categories"] = _appDbContext.Categories.ToList();
            return View(model);
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
    }
}
