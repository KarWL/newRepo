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

       public async Task<IActionResult> Create()
        {
            return View(await _context.PropertyInfo.ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
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
