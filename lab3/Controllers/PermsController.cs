using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab3.Data;
using lab3.Models;

namespace lab3.Controllers
{
    public class PermsController : Controller
    {
        private readonly AppDbContext _context;

        public PermsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Perms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perm.ToListAsync());
        }

        // GET: Perms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perm = await _context.Perm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perm == null)
            {
                return NotFound();
            }

            return View(perm);
        }

        // GET: Perms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Perm perm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perm);
        }

        // GET: Perms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perm = await _context.Perm.FindAsync(id);
            if (perm == null)
            {
                return NotFound();
            }
            return View(perm);
        }

        // POST: Perms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Perm perm)
        {
            if (id != perm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermExists(perm.Id))
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
            return View(perm);
        }

        // GET: Perms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perm = await _context.Perm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perm == null)
            {
                return NotFound();
            }

            return View(perm);
        }

        // POST: Perms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perm = await _context.Perm.FindAsync(id);
            if (perm != null)
            {
                _context.Perm.Remove(perm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermExists(int id)
        {
            return _context.Perm.Any(e => e.Id == id);
        }
    }
}
