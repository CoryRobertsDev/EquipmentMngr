using EquipmentMngr.Data;
using EquipmentMngr.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using SmartBreadcrumbs.Attributes;

namespace EquipmentMngr.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locations
        [Breadcrumb("Locations")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }


        // GET: Locations/Create
        [Breadcrumb("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")]
            Location location)
        {
            if (!ModelState.IsValid) return View(location);
            _context.Add(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Locations/Edit/5
        [Breadcrumb("Edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var location = await _context.Locations.FindAsync(id);
            if (location == null) return NotFound();
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,CreatedByUser,CreatedDate,ModifiedByUser,ModifiedDate")]
            Location location)
        {
            if (id != location.Id) return NotFound();

            if (!ModelState.IsValid) return View(location);
            try
            {
                _context.Update(location);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(location.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));

        }


        // POST: Locations/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}