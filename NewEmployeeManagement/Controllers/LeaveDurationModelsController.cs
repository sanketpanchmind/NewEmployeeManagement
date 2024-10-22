using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewEmployeeManagement.Areas.Identity.Data;
using NewEmployeeManagement.Models;

namespace NewEmployeeManagement.Controllers
{
    public class LeaveDurationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveDurationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveDurationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaveDurations.ToListAsync());
        }

        // GET: LeaveDurationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveDurationModel = await _context.LeaveDurations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveDurationModel == null)
            {
                return NotFound();
            }

            return View(leaveDurationModel);
        }

        // GET: LeaveDurationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveDurationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Duration,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveDurationModel leaveDurationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveDurationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveDurationModel);
        }

        // GET: LeaveDurationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveDurationModel = await _context.LeaveDurations.FindAsync(id);
            if (leaveDurationModel == null)
            {
                return NotFound();
            }
            return View(leaveDurationModel);
        }

        // POST: LeaveDurationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Duration,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveDurationModel leaveDurationModel)
        {
            if (id != leaveDurationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveDurationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveDurationModelExists(leaveDurationModel.Id))
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
            return View(leaveDurationModel);
        }

        // GET: LeaveDurationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveDurationModel = await _context.LeaveDurations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveDurationModel == null)
            {
                return NotFound();
            }

            return View(leaveDurationModel);
        }

        // POST: LeaveDurationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveDurationModel = await _context.LeaveDurations.FindAsync(id);
            if (leaveDurationModel != null)
            {
                _context.LeaveDurations.Remove(leaveDurationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveDurationModelExists(int id)
        {
            return _context.LeaveDurations.Any(e => e.Id == id);
        }
    }
}
