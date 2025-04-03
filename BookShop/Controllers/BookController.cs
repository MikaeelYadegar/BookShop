using BookShop.Models;
using Core.BookService;
using DatAccess.Data;
using DatAccess.Models;
using DatAccess.Repositories.CommentRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System.Drawing.Printing;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
       
        public BookController(BookService bookService)
        {
            _bookService = bookService;
           
        }
        public async Task<IActionResult> Index(string sortorder,int id,int pageNumber=1)
        {
            var book = await _bookService.GetBooksById(id);
            if(book==null)return NotFound();
            int pagesize = 5;
            var comments = await _bookService.GetCommentByID(id,pageNumber,pagesize);
            var totalComent=await _bookService.GetCommentCountByBookIdAsync(id);
            var totalPages=(int)Math.Ceiling((double)totalComent/pagesize);
            //int totalcount = await _bookService.GetCommentCount(productId);
            //ViewBag.TotalPage = (int)Math.Ceiling((double)totalcount / pagesize);
            //ViewBag.CurrentPage = page;
            //ViewBag.ProductId = productId;


            switch (sortorder)
            {
                case "newset":
                    comments = comments.OrderByDescending(c => c.CreatedAt).ToList();
                    break;
                case "oldest":
                    comments = comments.OrderBy(c => c.CreatedAt).ToList();
                    break;
            }
            var model = new BookDetailsViewModel
            {
                Book = book,
                Comments = comments,
                CurrentPage= pageNumber,
                TotalPages = totalPages,
                ProductId=id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment model)
        {
           Debug.WriteLine($"ProductIdهنگام ارسال فرم :{model.ProductId}");
            if(model.ProductId==0)
            {
                ModelState.AddModelError("", "محصول نا معتبر است");
                return RedirectToAction("Index", new {id=model.ProductId});
            }
            if (ModelState.IsValid)
            {
                await _bookService.AddComment(model);
                return RedirectToAction("Index", new { id = model.ProductId });
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BookList(int page = 1, int pagesize = 5, string search = null)
        {
            var data = await _bookService.GetBookPageInation(page, pagesize, search);
            ViewBag.seearch = search;
            return View(data);
        }

        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBooksById(id);
            return PartialView(book);
        }
        //public async Task<IActionResult> AddComment(Comment comment)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        if(Book.bok)
        //    }
          
            //if (comment.ProductId==0)
            //{
            //    var errors=ModelState.Values.SelectMany(v=>v.Errors)
            //                                 .Select(e=>e.ErrorMessage)
            //                                 .ToList();
            //    TempData["nok"] = "خطا در ارسال نظر:" +string.Join(",",errors);
            //    return RedirectToAction("Index", new { id = comment.ProductId });
            //}
            //await _bookService.AddComment(comment);
            //TempData["ok"] = "درسته";
           
            //return RedirectToAction("Index", new { id = comment.ProductId });
        }
        //    var comments = await _bookService.GetCommentByID(comment.ProductId);
        //        var book = await _bookService.GetBooksById(comment.ProductId);
        //        var model = new BookDetailsViewModel
        //        {
        //            Book = book,
        //            Comments = comments
        //        };
        //        return View("Index", model);
              
        //    }
        //    var invaidBook = await _bookService.GetBooksById(comment.ProductId);
        //    var invalidcomment = await _bookService.GetCommentByID(comment.ProductId);
        //    var invalidmodel = new BookDetailsViewModel
        //    {
        //        Book = invaidBook,
        //        Comments = invalidcomment
        //    };
        //    TempData["nok"] = "kdsj";
        //    return View("Index", invalidmodel);

        //}
    }

