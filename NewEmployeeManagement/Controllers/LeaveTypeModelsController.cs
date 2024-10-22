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
    public class LeaveTypeModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypeModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveTypeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaveTypes.ToListAsync());
        }

        // GET: LeaveTypeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeModel = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypeModel == null)
            {
                return NotFound();
            }

            return View(leaveTypeModel);
        }

        // GET: LeaveTypeModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LeaveType,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveTypeModel leaveTypeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeModel);
        }

        // GET: LeaveTypeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeModel = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypeModel == null)
            {
                return NotFound();
            }
            return View(leaveTypeModel);
        }

        // POST: LeaveTypeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LeaveType,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] LeaveTypeModel leaveTypeModel)
        {
            if (id != leaveTypeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeModelExists(leaveTypeModel.Id))
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
            return View(leaveTypeModel);
        }

        // GET: LeaveTypeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeModel = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveTypeModel == null)
            {
                return NotFound();
            }

            return View(leaveTypeModel);
        }

        // POST: LeaveTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveTypeModel = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypeModel != null)
            {
                _context.LeaveTypes.Remove(leaveTypeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeModelExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
    }
}
