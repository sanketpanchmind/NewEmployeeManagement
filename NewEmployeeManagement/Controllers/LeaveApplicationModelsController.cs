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
    public class LeaveApplicationModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveApplicationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveApplicationModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LeaveApplications.Include(l => l.Duration).Include(l => l.Employee).Include(l => l.LeaveType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LeaveApplicationModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplicationModel = await _context.LeaveApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveApplicationModel == null)
            {
                return NotFound();
            }

            return View(leaveApplicationModel);
        }

        // GET: LeaveApplicationModels/Create
        public IActionResult Create()
        {
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType");
            return View();
        }

        // POST: LeaveApplicationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveApplicationModel leaveApplicationModel)
        {
            if (ModelState.IsValid)
            {
                leaveApplicationModel.Status = "Pending";
                leaveApplicationModel.CreatedBy = "Admin";
                leaveApplicationModel.CreatedOn = DateTime.Now;

                _context.Add(leaveApplicationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }

        // GET: LeaveApplicationModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplicationModel = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplicationModel == null)
            {
                return NotFound();
            }
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }

        // POST: LeaveApplicationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveApplicationModel leaveApplicationModel)
        {
            if (id != leaveApplicationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                leaveApplicationModel.Status = "Approved";
                leaveApplicationModel.ModifiedBy = "Admin";
                leaveApplicationModel.ModifiedOn = DateTime.Now;
                try
                {
                  
                    _context.Update(leaveApplicationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveApplicationModelExists(leaveApplicationModel.Id))
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
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }


        public async Task<IActionResult> ApproveLeave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplicationModel = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplicationModel == null)
            {
                return NotFound();
            }
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveLeave(int id, LeaveApplicationModel leaveApplicationModel)
        {
            if (id != leaveApplicationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    leaveApplicationModel.Status = "Approved";
                    leaveApplicationModel.ModifiedBy = "HR";
                    leaveApplicationModel.ModifiedOn = DateTime.Now;

                    _context.Update(leaveApplicationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveApplicationModelExists(leaveApplicationModel.Id))
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
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }

        public async Task<IActionResult> RejectApproval(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var leaveApplicationModel = await _context.LeaveApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (leaveApplicationModel == null)
            {
                return NotFound();
            }

            return View(leaveApplicationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectApproval(int id, LeaveApplicationModel leaveApplicationModel)
        {


            if (id != leaveApplicationModel.Id)
            {
                return NotFound();
            }
            leaveApplicationModel = await _context.LeaveApplications.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    leaveApplicationModel.Status = "Rejected";
                    leaveApplicationModel.ModifiedBy = "Admin";
                    leaveApplicationModel.ModifiedOn = DateTime.Now;

                    _context.Update(leaveApplicationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveApplicationModelExists(leaveApplicationModel.Id))
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
            ViewData["DurationId"] = new SelectList(_context.LeaveDurations, "Id", "Duration", leaveApplicationModel.DurationId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", leaveApplicationModel.EmployeeId);
            ViewData["LeavetypeId"] = new SelectList(_context.LeaveTypes, "Id", "LeaveType", leaveApplicationModel.LeavetypeId);
            return View(leaveApplicationModel);
        }

        // GET: LeaveApplicationModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveApplicationModel = await _context.LeaveApplications
                .Include(l => l.Duration)
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveApplicationModel == null)
            {
                return NotFound();
            }

            return View(leaveApplicationModel);
        }

        // POST: LeaveApplicationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveApplicationModel = await _context.LeaveApplications.FindAsync(id);
            if (leaveApplicationModel != null)
            {
                _context.LeaveApplications.Remove(leaveApplicationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveApplicationModelExists(int id)
        {
            return _context.LeaveApplications.Any(e => e.Id == id);
        }
    }
}
