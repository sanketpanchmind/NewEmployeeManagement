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
    public class DesignationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DesignationModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Designations.Include(d => d.Departments);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DesignationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationModel = await _context.Designations
                .Include(d => d.Departments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationModel == null)
            {
                return NotFound();
            }

            return View(designationModel);
        }

        // GET: DesignationModels/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "DepartmentName");
            return View();
        }

        // POST: DesignationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Designation,DeptId,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] DesignationModel designationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(designationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "DepartmentName", designationModel.DeptId);
            return View(designationModel);
        }

        // GET: DesignationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationModel = await _context.Designations.FindAsync(id);
            if (designationModel == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", designationModel.DeptId);
            return View(designationModel);
        }

        // POST: DesignationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Designation,DeptId,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn")] DesignationModel designationModel)
        {
            if (id != designationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(designationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationModelExists(designationModel.Id))
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
            ViewData["DeptId"] = new SelectList(_context.Departments, "Id", "Id", designationModel.DeptId);
            return View(designationModel);
        }

        // GET: DesignationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var designationModel = await _context.Designations
                .Include(d => d.Departments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (designationModel == null)
            {
                return NotFound();
            }

            return View(designationModel);
        }

        // POST: DesignationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var designationModel = await _context.Designations.FindAsync(id);
            if (designationModel != null)
            {
                _context.Designations.Remove(designationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationModelExists(int id)
        {
            return _context.Designations.Any(e => e.Id == id);
        }
    }
}
