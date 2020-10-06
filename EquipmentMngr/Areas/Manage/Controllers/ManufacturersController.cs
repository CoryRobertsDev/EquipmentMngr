using System.Linq;
using System.Threading.Tasks;
using EquipmentMngr.Data;
using EquipmentMngr.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBreadcrumbs.Attributes;

namespace EquipmentMngr.Areas.Manage.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manufacturers
        [Breadcrumb("Manufacturers")]
        [Area("Manage")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacturers.ToListAsync());
        }


        // GET: Manufacturers/Create
        [Breadcrumb("Create")]
        [Area("Manage")]

        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);
            _context.Add(manufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Manufacturers/Edit/5
        [Breadcrumb("Edit")]
        [Area("Manage")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturer = await _context.Manufacturers.FindAsync(id).ConfigureAwait(true);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")] Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
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
            return View(manufacturer);
        }


        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
