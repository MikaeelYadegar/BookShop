using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatAccess.Data;
using DatAccess.Models;
using Core.BookService;
using Core.AuthoreService;
using DatAccess.Models;

namespace AdminBookShop.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService;
        private readonly AuthoreService _authoreService;

        public BooksController(BookService bookService,AuthoreService authoreService)
        {
            _bookService = bookService;
            _authoreService = authoreService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var data = await _bookService.GetBooksWithAuthore();
            return View(data);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var books=await _bookService.GetBooksWithAuthore(a=>a.Id == id);
            var book=books.FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult>Create()
        {
            ViewData["AuthoreId"] = new SelectList(await _authoreService.GetAllAuthores(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (BookDto book)
        {
            if (ModelState.IsValid)
            {
                 await _bookService.CreateBook(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthoreId"] = new SelectList(await _authoreService.GetAllAuthores(), "Id", "Name", book.AuthoreId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetBookDtoById(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthoreId"] = new SelectList(await _authoreService.GetAllAuthores(), "Id", "Name", book.AuthoreId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,BookDto book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.Update(book);
                }
                catch (DbUpdateConcurrencyException)
                {
              
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthoreId"] = new SelectList(await _authoreService.GetAllAuthores(), "Id", "Name", book.AuthoreId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var books= await _bookService.GetBooksWithAuthore(x=>x.Id == id);
            var book=books.FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _bookService.GetBooksWithAuthore(x => x.Id == id);
            var book = books.FirstOrDefault();
            await _bookService.Delete(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
