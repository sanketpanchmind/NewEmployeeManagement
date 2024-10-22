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
    public class LeaveStatusModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveStatusModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveStatusModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaveStatus.ToListAsync());
        }

        // GET: LeaveStatusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveStatusModel = await _context.LeaveStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveStatusModel == null)
            {
                return NotFound();
            }

            return View(leaveStatusModel);
        }

        // GET: LeaveStatusModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveStatusModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LeaveStatus,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveStatusModel leaveStatusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveStatusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveStatusModel);
        }

        // GET: LeaveStatusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveStatusModel = await _context.LeaveStatus.FindAsync(id);
            if (leaveStatusModel == null)
            {
                return NotFound();
            }
            return View(leaveStatusModel);
        }

        // POST: LeaveStatusModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LeaveStatus,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveStatusModel leaveStatusModel)
        {
            if (id != leaveStatusModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveStatusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveStatusModelExists(leaveStatusModel.Id))
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
            return View(leaveStatusModel);
        }

        // GET: LeaveStatusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveStatusModel = await _context.LeaveStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveStatusModel == null)
            {
                return NotFound();
            }

            return View(leaveStatusModel);
        }

        // POST: LeaveStatusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveStatusModel = await _context.LeaveStatus.FindAsync(id);
            if (leaveStatusModel != null)
            {
                _context.LeaveStatus.Remove(leaveStatusModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveStatusModelExists(int id)
        {
            return _context.LeaveStatus.Any(e => e.Id == id);
        }
    }
}
