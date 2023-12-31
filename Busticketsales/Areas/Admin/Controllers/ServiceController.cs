using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly Datacontext _context;
        public ServiceController(Datacontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sr = _context.Services.Where(m => m.IsActive == true).OrderBy(m => m.ServiceID).ToList();
            return View(sr);
        }

        // thêm mới sevice
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        // Chính sửa service
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Services.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service mn)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        // xem chi tiet service
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Services
                        .FirstOrDefault(m => (m.ServiceID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        // xoa service
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var service = _context.Services.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }
        [HttpPost]
        // xoa service
        public IActionResult Delete(long id)
        {
            var Deletesr = _context.Services.Find(id);
            if (Deletesr == null)
            {
                return NotFound();
            }
            _context.Services.Remove(Deletesr);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

