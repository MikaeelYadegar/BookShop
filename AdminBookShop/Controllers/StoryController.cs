using Core.StoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AdminBookShop.Controllers
{
    public class StoryController : Controller
    {
        private readonly IStoryService _storyService;
        public StoryController(IStoryService storyService)
        {
            _storyService = storyService;
            
        }
        public IActionResult Index()
        {
            var stories=_storyService.GetAllStories();
            return View(stories);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _storyService.DeleteStory(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(IFormFile file)
        {
            if(file!=null)
            {
                _storyService.AddStory(file);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
