using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services.Models.WorkModels;

namespace Services.Controllers
{
    public class ProjectRolesController : Controller
    {
        private readonly WorkContext _context;

        public ProjectRolesController(WorkContext context)
        {
            _context = context;
        }

        // GET: ProjectRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectRole.ToListAsync());
        }

        // GET: ProjectRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectRole = await _context.ProjectRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectRole == null)
            {
                return NotFound();
            }

            return View(projectRole);
        }

        // GET: ProjectRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName")] ProjectRole projectRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectRole);
        }

        // GET: ProjectRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectRole = await _context.ProjectRole.FindAsync(id);
            if (projectRole == null)
            {
                return NotFound();
            }
            return View(projectRole);
        }

        // POST: ProjectRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName")] ProjectRole projectRole)
        {
            if (id != projectRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectRoleExists(projectRole.Id))
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
            return View(projectRole);
        }

        // GET: ProjectRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectRole = await _context.ProjectRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectRole == null)
            {
                return NotFound();
            }

            return View(projectRole);
        }

        // POST: ProjectRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectRole = await _context.ProjectRole.FindAsync(id);
            _context.ProjectRole.Remove(projectRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectRoleExists(int id)
        {
            return _context.ProjectRole.Any(e => e.Id == id);
        }
    }
}
