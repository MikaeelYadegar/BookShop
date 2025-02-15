using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatAccess.Data;
using DatAccess.Models;
using Core.AuthoreService;

namespace AdminBookShop.Controllers
{
    public class AuthoresController : Controller
    {
        private readonly AuthoreService _authoreService;

        public AuthoresController(AuthoreService authoreService)
        {
            _authoreService = authoreService;
        }

        // GET: Authores
        public async Task<IActionResult> Index()
        {
            return View(await _authoreService.GetAllAuthores());
        }

        // GET: Authores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authore = await _authoreService.GetAllAuthoresByID(id.Value);
              
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
            await  _authoreService.CreateAuthore(authore);
              
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

            var authore = await _authoreService.GetAllAuthoresByID(id.Value);
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
                   await _authoreService.UpdateAuthore(authore);
                 
                }
                catch (DbUpdateConcurrencyException)
                {
     
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

            var authore = await _authoreService.GetAllAuthoresByID(id.Value);
                
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

            var authore = await _authoreService.GetAllAuthoresByID(id);
         await   _authoreService.DeleteAuthore(authore);
            return RedirectToAction(nameof(Index));
        }


    }
}
