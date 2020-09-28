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
    public class AssignmentsDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssignmentsDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssignmentsDetail.ToListAsync());
        }

        // GET: AssignmentsDetails
        public async Task<IActionResult> Active()
        {
            return View(await _context.AssignmentsDetail.ToListAsync());
        }
        // GET: AssignmentsDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignmentsDetail = await _context.AssignmentsDetail
                .FirstOrDefaultAsync(m => m.ColleagueId == id);
            if (assignmentsDetail == null)
            {
                return NotFound();
            }

            return View(assignmentsDetail);
        }

      
    
        private bool AssignmentsDetailExists(string id)
        {
            return _context.AssignmentsDetail.Any(e => e.ColleagueId == id);
        }
    }
}
