using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatAccess.Data;
using DatAccess.Models;

namespace AdminBookShop.Controllers
{
    public class AuthoresController : Controller
    {
        private readonly BookDbContext _context;

        public AuthoresController(BookDbContext context)
        {
            _context = context;
        }

        // GET: Authores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authores.ToListAsync());
        }

        // GET: Authores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authore = await _context.Authores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authore == null)
            {
                return NotFound();
            }

            return View(authore);
        }

        // GET: Authores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Authore authore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authore);
        }

        // GET: Authores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authore = await _context.Authores.FindAsync(id);
            if (authore == null)
            {
                return NotFound();
            }
            return View(authore);
        }

        // POST: Authores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Authore authore)
        {
            if (id != authore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthoreExists(authore.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(authore);
        }

        // GET: Authores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authore = await _context.Authores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authore == null)
            {
                return NotFound();
            }

            return View(authore);
        }

        // POST: Authores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authore = await _context.Authores.FindAsync(id);
            if (authore != null)
            {
                _context.Authores.Remove(authore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthoreExists(int id)
        {
            return _context.Authores.Any(e => e.Id == id);
        }
    }
}
