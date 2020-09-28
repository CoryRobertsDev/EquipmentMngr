using EquipmentMngr.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;
using System.Linq;
using EquipmentMngr.Data;

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

        public IActionResult Welcome()
        {
            

            return View();
        }
        [DefaultBreadcrumb("Home")]
        public IActionResult Index()
        {
            

            return View();
        }

        [Breadcrumb("Dashboard")]
        public IActionResult Main()
        {
            ViewData["AssignmentCount"] = _context.Assignments.Count();
            ViewData["EquipmentCount"] = _context.Equipment.Count();
            ViewData["RepairCount"] = _context.Repairs.Count();

            ViewData["MonitorCount"] = _context.Equipment.Count(e => e.EquipmentTypeId == '2');
            ViewData["PcCount"] = _context.Equipment.Count(e => e.EquipmentTypeId == '6');
            ViewData["LaptopCountTotal"] = _context.Equipment.Count(e => e.EquipmentTypeId == '2');
            ViewData["LaptopCountUnassigned"] = _context.Equipment.Count(e => e.EquipmentTypeId == '2');

            return View();
        }

        [Breadcrumb("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}