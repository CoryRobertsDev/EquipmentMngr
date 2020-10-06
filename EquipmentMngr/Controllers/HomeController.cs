using System;
using System.Collections.Generic;
using EquipmentMngr.Data;
using EquipmentMngr.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EquipmentMngr.Data.Entities;
using EquipmentMngr.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMngr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [DefaultBreadcrumb("Home")]
        public async Task<IActionResult> Index(string id)
        {
            var assignments = from a in _context.Assignments
                select a;

            if (!String.IsNullOrEmpty(id))
            {
                assignments = assignments.Where(s => s.ColleagueId.Contains(id));
            }

            return View(await assignments.ToListAsync());
        }

        [Breadcrumb("Dashboard")]
        [Authorize(Roles = "Basic, Admin, SuperAdmin")]
        public IActionResult Main(string searchString)
        {
            
            var assignments = from m in _context.Assignments
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                assignments = assignments.Where(s => s.ColleagueId.Contains(searchString));
            }

      

            //var assignmentCount = _context.Assignments
            //    .GroupBy(c => c.ColleagueId)
            //    .Select(c => new
            //    {
            //        c.Key,
            //        DistinctCount = c.Select(x => x.ColleagueId).Distinct().Count(),
            //        assignmentCount = ViewData["AssignmentCount"]
            ////    });

            //ViewData["AssignmentCount"] = assignmentCount;

            var assignmentCount1 = _context.Assignments.CountOrNull;
            ViewData["AssignmentCount"] = _context.Assignments.Count();
            ViewData["EquipmentCount"] = _context.Equipment.Count();
            ViewData["RepairCount"] = _context.Repairs.Count();
            ViewData["MonitorCount"] = _context.Equipment.Count(e => e.EquipmentTypeId == '1');
            ViewData["Keyboard"] = _context.Equipment.Count(e => e.EquipmentTypeId == '6');
            ViewData["LaptopCountTotal"] = _context.Equipment.Count(e => e.EquipmentTypeId == '2');
            //ViewData["LaptopCountUnassigned"] = _context.Equipment.Count(e => e.EquipmentTypeId == '2');

            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}