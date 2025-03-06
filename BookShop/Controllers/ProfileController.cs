using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
