using Core.BookService;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        public readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var book=await _bookService.GetBooksById(id);
            return View(book);
        }


        public async Task<IActionResult> BookList(int page = 1, int pagesize = 5,string search=null)
        {
            var data= await _bookService.GetBookPageInation(page,pagesize,search);
            ViewBag.seearch=search;
            return View(data);
        }


    }
}
