using System.Diagnostics;
using BookShop.Models;
using Core.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;

        public HomeController(ILogger<HomeController> logger,BookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task <IActionResult> Index( )
        {
           
            return View();
        }
         
        public IActionResult aboutUs()
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
