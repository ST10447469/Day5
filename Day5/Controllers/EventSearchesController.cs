using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day5.Data;
using Day5.Models;

namespace Day5.Controllers
{
    public class EventSearchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventSearchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventSearches
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventSearch.ToListAsync());
        }

        // GET: EventSearches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSearch = await _context.EventSearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventSearch == null)
            {
                return NotFound();
            }

            return View(eventSearch);
        }

        // GET: EventSearches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventSearches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Type")] EventSearch eventSearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventSearch);
        }

        // GET: EventSearches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSearch = await _context.EventSearch.FindAsync(id);
            if (eventSearch == null)
            {
                return NotFound();
            }
            return View(eventSearch);
        }

        // POST: EventSearches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Type")] EventSearch eventSearch)
        {
            if (id != eventSearch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventSearchExists(eventSearch.Id))
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
            return View(eventSearch);
        }

        // GET: EventSearches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSearch = await _context.EventSearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventSearch == null)
            {
                return NotFound();
            }

            return View(eventSearch);
        }

        // POST: EventSearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSearch = await _context.EventSearch.FindAsync(id);
            if (eventSearch != null)
            {
                _context.EventSearch.Remove(eventSearch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventSearchExists(int id)
        {
            return _context.EventSearch.Any(e => e.Id == id);
        }
    }
}
