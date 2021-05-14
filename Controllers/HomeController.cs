using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using newRepo.Data;
using newRepo.Models;

namespace newRepo.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly PropertyDB _context;

        public HomeController(PropertyDB context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users()
        {
            return View(await _context.User.ToListAsync());
        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.User                   
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            return View(data);
        }

        public IActionResult Edit()
        {
            return View();
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.User
                    .Include(s => s.PropertyInfos)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            return View(data);
        }

        // public IActionResult Create()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
