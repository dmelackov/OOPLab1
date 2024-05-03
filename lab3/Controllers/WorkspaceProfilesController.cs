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
    public class WorkspaceProfilesController : Controller
    {
        private readonly AppDbContext _context;

        public WorkspaceProfilesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkspaceProfiles
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkspaceProfile.Include(w => w.Profile).Include(w => w.Role).Include(w => w.Workspace);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkspaceProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaceProfile = await _context.WorkspaceProfile
                .Include(w => w.Profile)
                .Include(w => w.Role)
                .Include(w => w.Workspace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workspaceProfile == null)
            {
                return NotFound();
            }

            return View(workspaceProfile);
        }

        // GET: WorkspaceProfiles/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(_context.Profile, "Id", "Id");
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id");
            ViewData["WorkspaceId"] = new SelectList(_context.Workspace, "Id", "Id");
            return View();
        }

        // POST: WorkspaceProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfileId,WorkspaceId,RoleId")] WorkspaceProfile workspaceProfile)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(workspaceProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfileId"] = new SelectList(_context.Profile, "Id", "Id", workspaceProfile.ProfileId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", workspaceProfile.RoleId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspace, "Id", "Id", workspaceProfile.WorkspaceId);
            return View(workspaceProfile);
        }

        // GET: WorkspaceProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaceProfile = await _context.WorkspaceProfile.FindAsync(id);
            if (workspaceProfile == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_context.Profile, "Id", "Id", workspaceProfile.ProfileId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", workspaceProfile.RoleId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspace, "Id", "Id", workspaceProfile.WorkspaceId);
            return View(workspaceProfile);
        }

        // POST: WorkspaceProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfileId,WorkspaceId,RoleId")] WorkspaceProfile workspaceProfile)
        {
            if (id != workspaceProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workspaceProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkspaceProfileExists(workspaceProfile.Id))
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
            ViewData["ProfileId"] = new SelectList(_context.Profile, "Id", "Id", workspaceProfile.ProfileId);
            ViewData["RoleId"] = new SelectList(_context.Role, "Id", "Id", workspaceProfile.RoleId);
            ViewData["WorkspaceId"] = new SelectList(_context.Workspace, "Id", "Id", workspaceProfile.WorkspaceId);
            return View(workspaceProfile);
        }

        // GET: WorkspaceProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workspaceProfile = await _context.WorkspaceProfile
                .Include(w => w.Profile)
                .Include(w => w.Role)
                .Include(w => w.Workspace)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workspaceProfile == null)
            {
                return NotFound();
            }

            return View(workspaceProfile);
        }

        // POST: WorkspaceProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workspaceProfile = await _context.WorkspaceProfile.FindAsync(id);
            if (workspaceProfile != null)
            {
                _context.WorkspaceProfile.Remove(workspaceProfile);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkspaceProfileExists(int id)
        {
            return _context.WorkspaceProfile.Any(e => e.Id == id);
        }
    }
}
