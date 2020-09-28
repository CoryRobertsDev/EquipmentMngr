using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquipmentMngr.Data;
using EquipmentMngr.Data.Entities;
using SmartBreadcrumbs.Attributes;

namespace EquipmentMngr.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        [Breadcrumb("Assignments")]
        public async Task<IActionResult> Index()
        {

            var applicationDbContext = _context.Assignments.Include(a => a.Department).Include(a => a.Employee).Include(a => a.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        [Breadcrumb("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Department)
                .Include(a => a.Employee)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        [Breadcrumb("Create")]
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ColleagueId,EquipmentId,RoomNumber,DepartmentId,LocationId,EmployeeId,Unassigned,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", assignment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", assignment.LocationId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        [Breadcrumb("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", assignment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", assignment.LocationId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColleagueId,EquipmentId,RoomNumber,DepartmentId,LocationId,EmployeeId,Unassigned,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Assignment assignment)
        {
            if (id != assignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", assignment.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Name", assignment.EmployeeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", assignment.LocationId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        [Breadcrumb("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Department)
                .Include(a => a.Employee)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}
