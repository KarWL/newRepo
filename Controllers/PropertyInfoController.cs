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
    public class PropertyInfoController : Controller
    {
        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly PropertyDB _context;

        public PropertyInfoController(PropertyDB context)
        {
            _context = context;
        }

        public JsonResult CreatePropertyInfo(string Name, string Type, string Description, int UserId)
        {
            PropertyInfo propertyInfo = new PropertyInfo();
            propertyInfo.Name = Name;
            propertyInfo.Type = Type;
            propertyInfo.Description = Description;

            var user =_context.User.FirstOrDefault(m => m.Id == UserId);

            propertyInfo.User = user;

            _context.Add(propertyInfo);
            _context.SaveChanges();

            return Json(null);
        }

        //home page
        public IActionResult Index()
        {
            return View();
        }

        //user page 
        public async Task<IActionResult> Users()
        {
            return View(await _context.User.ToListAsync());
        }

        //create page
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

        //edit page
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.PropertyInfo
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Description")] PropertyInfo propertyInfo)
        {
            if (id != propertyInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction("Users");
            }
            return View(propertyInfo);
        }

        //delete       
        // public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        // {
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.PropertyInfo
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            return View(data);
        }

        //if can trgger this action and can navigate back to the users page

        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asset = await _context.PropertyInfo.FindAsync(id);
            if (asset == null)
            {
                return RedirectToAction(nameof(Users));
            }

            try
            {
                _context.PropertyInfo.Remove(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Users));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


        //details page
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

        //error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
