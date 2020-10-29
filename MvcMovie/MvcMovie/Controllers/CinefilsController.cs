using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CinefilsController : Controller
    {
        private readonly MvcMovieContext _context;

        public CinefilsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Cinefils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinefil.ToListAsync());
        }

        // GET: Cinefils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefil = await _context.Cinefil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinefil == null)
            {
                return NotFound();
            }

            return View(cinefil);
        }

        // GET: Cinefils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinefils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,email")] Cinefil cinefil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinefil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinefil);
        }

        // GET: Cinefils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefil = await _context.Cinefil.FindAsync(id);
            if (cinefil == null)
            {
                return NotFound();
            }
            return View(cinefil);
        }

        // POST: Cinefils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,email")] Cinefil cinefil)
        {
            if (id != cinefil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinefil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinefilExists(cinefil.Id))
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
            return View(cinefil);
        }

        // GET: Cinefils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinefil = await _context.Cinefil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinefil == null)
            {
                return NotFound();
            }

            return View(cinefil);
        }

        // POST: Cinefils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinefil = await _context.Cinefil.FindAsync(id);
            _context.Cinefil.Remove(cinefil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinefilExists(int id)
        {
            return _context.Cinefil.Any(e => e.Id == id);
        }
    }
}
