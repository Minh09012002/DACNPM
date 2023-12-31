using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Busticketsales.Models;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RouteController : Controller
    {
        private readonly Datacontext _context;
        public RouteController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var router = _context.Routes.Where(m => m.IsActive == true).OrderBy(m => m.RouteID).ToList();
            return View(router);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Busticketsales.Models.Route router)
        {
            if (ModelState.IsValid)
            {
                _context.Routes.Add(router);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        // Chính sửa 
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Routes.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Edit(Busticketsales.Models.Route r)
        {
            if (ModelState.IsValid)
            {
                _context.Routes.Update(r);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var router = _context.Routes.Find(id);

            if (router == null)
            {
                return NotFound();
            }
            return View(router);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var member = _context.Routes.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var Deleterouter = _context.Routes.Find(id);
            if (Deleterouter == null)
            {
                return NotFound();
            }
            _context.Routes.Remove(Deleterouter);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
