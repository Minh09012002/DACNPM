using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly Datacontext _context;
        public ContactController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contact = _context.ContactQualities.Where(m => (m.IsActive == true)&&(m.Position == 1)).OrderBy(m => m.ContactQualityID).ToList();
            return View(contact);
        }


        // thêm mới sevice
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactQuality contact)
        {
            if (ModelState.IsValid)
            {
                _context.ContactQualities.Add(contact);
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
            var mn = _context.ContactQualities.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactQuality mn)
        {
            if (ModelState.IsValid)
            {
                _context.ContactQualities.Update(mn);
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
            var contact = _context.ContactQualities
                        .FirstOrDefault(m => (m.ContactQualityID == id) && (m.IsActive == true));
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        // xoa service
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contact = _context.ContactQualities.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        [HttpPost]
        // xoa service
        public IActionResult Delete(long id)
        {
            var Deletect = _context.ContactQualities.Find(id);
            if (Deletect == null)
            {
                return NotFound();
            }
            _context.ContactQualities.Remove(Deletect);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
