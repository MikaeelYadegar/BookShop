using System.Buffers.Text;
using System.Diagnostics;
using BookShop.Models;
using Core.BookService;
using Core.StoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;
        private readonly IStoryService _storyService;

        public HomeController(ILogger<HomeController> logger,BookService bookService,IStoryService storyService)
        {
            _logger = logger;
            _bookService = bookService;
            _storyService = storyService;
        }

        public IActionResult Index( )
        {
         var storis=_storyService.GetAllStories()
                .OrderByDescending(s=>s.CreatedAt)
                .Take(5)
                .ToList();
            return View(storis);
        }
        [HttpGet]
        public IActionResult GetStoryData(int id)
        {
            var story=_storyService.GetStoryById(id);
            if(story == null) 
                return NotFound();
            var base64=Convert.ToBase64String(story.MediaData);
            return Json(new { base64, mimeType = story.MediaMimeType });
        }
        [Authorize]
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
