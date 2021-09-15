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
    public class BusinessActivitiesController : Controller
    {
        private readonly WorkContext _context;

        public BusinessActivitiesController(WorkContext context)
        {
            _context = context;
        }

        // GET: BusinessActivities
        public async Task<IActionResult> Index()
        {
            var workContext = _context.BusinessActivtiy.Include(b => b.Company);
            return View(await workContext.ToListAsync());
        }

        // GET: BusinessActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessActivity = await _context.BusinessActivtiy
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (businessActivity == null)
            {
                return NotFound();
            }

            return View(businessActivity);
        }

        // GET: BusinessActivities/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch");
            return View();
        }

        // POST: BusinessActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessId,ActivityName,CompanyId")] BusinessActivity businessActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", businessActivity.CompanyId);
            return View(businessActivity);
        }

        // GET: BusinessActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessActivity = await _context.BusinessActivtiy.FindAsync(id);
            if (businessActivity == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", businessActivity.CompanyId);
            return View(businessActivity);
        }

        // POST: BusinessActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusinessId,ActivityName,CompanyId")] BusinessActivity businessActivity)
        {
            if (id != businessActivity.BusinessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessActivityExists(businessActivity.BusinessId))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Branch", businessActivity.CompanyId);
            return View(businessActivity);
        }

        // GET: BusinessActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessActivity = await _context.BusinessActivtiy
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.BusinessId == id);
            if (businessActivity == null)
            {
                return NotFound();
            }

            return View(businessActivity);
        }

        // POST: BusinessActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessActivity = await _context.BusinessActivtiy.FindAsync(id);
            _context.BusinessActivtiy.Remove(businessActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessActivityExists(int id)
        {
            return _context.BusinessActivtiy.Any(e => e.BusinessId == id);
        }
    }
}
