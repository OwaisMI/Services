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
    public class SocialsController : Controller
    {
        private readonly WorkContext _context;

        public SocialsController(WorkContext context)
        {
            _context = context;
        }

        // GET: Socials
        public async Task<IActionResult> Index()
        {
            var workContext = _context.Socials.Include(s => s.Company);
            return View(await workContext.ToListAsync());
        }

        // GET: Socials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socials = await _context.Socials
                .Include(s => s.Company)
                .FirstOrDefaultAsync(m => m.SocialId == id);
            if (socials == null)
            {
                return NotFound();
            }

            return View(socials);
        }

        // GET: Socials/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch");
            return View();
        }

        // POST: Socials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SocialId,SocialName,CompanyId,Url")] Socials socials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", socials.CompanyId);
            return View(socials);
        }

        // GET: Socials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socials = await _context.Socials.FindAsync(id);
            if (socials == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", socials.CompanyId);
            return View(socials);
        }

        // POST: Socials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SocialId,SocialName,CompanyId,Url")] Socials socials)
        {
            if (id != socials.SocialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialsExists(socials.SocialId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", socials.CompanyId);
            return View(socials);
        }

        // GET: Socials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socials = await _context.Socials
                .Include(s => s.Company)
                .FirstOrDefaultAsync(m => m.SocialId == id);
            if (socials == null)
            {
                return NotFound();
            }

            return View(socials);
        }

        // POST: Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socials = await _context.Socials.FindAsync(id);
            _context.Socials.Remove(socials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialsExists(int id)
        {
            return _context.Socials.Any(e => e.SocialId == id);
        }
    }
}
