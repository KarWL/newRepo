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
    public class AssetController : Controller
    {
        private readonly PropertyDB _context;

        public AssetController(PropertyDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyInfo.ToListAsync());
        }

        // private readonly ILogger<HomeController> _logger;

        // public AssetController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

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
