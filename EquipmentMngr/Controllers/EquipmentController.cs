using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquipmentMngr.Data;
using EquipmentMngr.Data.Entities;

namespace EquipmentMngr.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipment
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Manufacturer).Include(e => e.Status).Include(e => e.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Equipment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.EquipmentType)
                .Include(e => e.Manufacturer)
                .Include(e => e.Status)
                .Include(e => e.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipment/Create
        public IActionResult Create()
        {
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "Id", "Name");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name");
            return View();
        }

        // POST: Equipment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipmentTypeId,VendorId,ManufacturerId,Model,SubModel,SerialNum,ServiceTag,DateReceived,Warranty,StatusId,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "Id", "Name", equipment.EquipmentTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", equipment.ManufacturerId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", equipment.StatusId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", equipment.VendorId);
            return View(equipment);
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "Id", "Name", equipment.EquipmentTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", equipment.ManufacturerId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", equipment.StatusId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", equipment.VendorId);
            return View(equipment);
        }

        // POST: Equipment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentTypeId,VendorId,ManufacturerId,Model,SubModel,SerialNum,ServiceTag,DateReceived,Warranty,StatusId,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Id))
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
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "Id", "Name", equipment.EquipmentTypeId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", equipment.ManufacturerId);
            ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Name", equipment.StatusId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Name", equipment.VendorId);
            return View(equipment);
        }

        // GET: Equipment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.EquipmentType)
                .Include(e => e.Manufacturer)
                .Include(e => e.Status)
                .Include(e => e.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipment.Any(e => e.Id == id);
        }
    }
}
