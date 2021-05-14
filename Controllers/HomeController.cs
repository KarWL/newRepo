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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private readonly PropertyDB _context;

        public HomeController(PropertyDB context)
        {
            _context = context;
        }

        //home page
        public IActionResult Index()
        {
            return View();
        }

    }
}
