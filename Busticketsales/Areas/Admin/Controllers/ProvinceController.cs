using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvinceController : Controller
    {
        private readonly Datacontext _context;
        public ProvinceController(Datacontext contex)
        {
            _context = contex;
        }

        public IActionResult Index()
        {
            var province = _context.Bookings.Where(m => (m.IsActive == true)).ToList();
            return View(province);
        }

        // thêm mới bus
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking pro)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Add(pro);
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
            var b = _context.Bookings.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Booking b)
        {
            if (ModelState.IsValid)
            {
                _context.Bookings.Update(b);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(b);
        }
        // xoa 
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var b = _context.Bookings.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }
        [HttpPost]
        // xoa service
        public IActionResult Delete(long id)
        {
            var Deletect = _context.Bookings.Find(id);
            if (Deletect == null)
            {
                return NotFound();
            }
            _context.Bookings.Remove(Deletect);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
