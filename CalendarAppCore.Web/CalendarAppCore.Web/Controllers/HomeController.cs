using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalendarAppCore.Web.Data;
using Microsoft.AspNetCore.Mvc;
using CalendarAppCore.Web.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CalendarAppCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetEvents()
        {
            using (_context)
            {
                var events = _context.Events.ToList();
                return new JsonResult(events, new JsonSerializerSettings());
            }
        }
    }
}
