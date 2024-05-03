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
    public class RolePermsController : Controller
    {
        private readonly AppDbContext _context;

        public RolePermsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RolePerms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.RolePerm.Include(r => r.Perm).Include(r => r.Role);
            return View(await appDbContext.ToListAsync());
        }

        // GET: RolePerms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePerm = await _context.RolePerm
                .Include(r => r.Perm)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.PermsId == id);
            if (rolePerm == null)
            {
                return NotFound();
            }

            return View(rolePerm);
        }

        // GET: RolePerms/Create
        public IActionResult Create()
        {
            ViewData["PermsId"] = new SelectList(_context.Perm, "Id", "Name");
            ViewData["RolesId"] = new SelectList(_context.Role, "Id", "Name");
            return View();
        }

        // POST: RolePerms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermsId,RolesId")] RolePerm rolePerm)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(rolePerm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermsId"] = new SelectList(_context.Perm, "Id", "Name", rolePerm.PermsId);
            ViewData["RolesId"] = new SelectList(_context.Role, "Id", "Name", rolePerm.RolesId);
            return View(rolePerm);
        }

        // GET: RolePerms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePerm = await _context.RolePerm.FindAsync(id);
            if (rolePerm == null)
            {
                return NotFound();
            }
            ViewData["PermsId"] = new SelectList(_context.Perm, "Id", "Id", rolePerm.PermsId);
            ViewData["RolesId"] = new SelectList(_context.Role, "Id", "Id", rolePerm.RolesId);
            return View(rolePerm);
        }

        // POST: RolePerms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermsId,RolesId")] RolePerm rolePerm)
        {
            if (id != rolePerm.PermsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rolePerm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolePermExists(rolePerm.PermsId))
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
            ViewData["PermsId"] = new SelectList(_context.Perm, "Id", "Id", rolePerm.PermsId);
            ViewData["RolesId"] = new SelectList(_context.Role, "Id", "Id", rolePerm.RolesId);
            return View(rolePerm);
        }

        // GET: RolePerms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rolePerm = await _context.RolePerm
                .Include(r => r.Perm)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(m => m.PermsId == id);
            if (rolePerm == null)
            {
                return NotFound();
            }

            return View(rolePerm);
        }

        // POST: RolePerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rolePerm = await _context.RolePerm.FindAsync(id);
            if (rolePerm != null)
            {
                _context.RolePerm.Remove(rolePerm);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolePermExists(int id)
        {
            return _context.RolePerm.Any(e => e.PermsId == id);
        }
    }
}
