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
    public class UserSearchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserSearchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserSearches
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSearch.ToListAsync());
        }

        // GET: UserSearches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSearch = await _context.UserSearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSearch == null)
            {
                return NotFound();
            }

            return View(userSearch);
        }

        // GET: UserSearches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserSearches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email")] UserSearch userSearch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSearch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userSearch);
        }

        // GET: UserSearches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSearch = await _context.UserSearch.FindAsync(id);
            if (userSearch == null)
            {
                return NotFound();
            }
            return View(userSearch);
        }

        // POST: UserSearches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email")] UserSearch userSearch)
        {
            if (id != userSearch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSearch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSearchExists(userSearch.Id))
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
            return View(userSearch);
        }

        // GET: UserSearches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSearch = await _context.UserSearch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSearch == null)
            {
                return NotFound();
            }

            return View(userSearch);
        }

        // POST: UserSearches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSearch = await _context.UserSearch.FindAsync(id);
            if (userSearch != null)
            {
                _context.UserSearch.Remove(userSearch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSearchExists(int id)
        {
            return _context.UserSearch.Any(e => e.Id == id);
        }
    }
}
