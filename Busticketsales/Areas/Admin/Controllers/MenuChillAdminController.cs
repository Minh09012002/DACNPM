using Busticketsales.Areas.Admin.Models;
using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuChillController : Controller
    {
        private readonly Datacontext _context;
        public MenuChillController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var managechill = _context.Adminmenus.Where(m => m.ItemLevel == 2).OrderBy(n => n.AdminMenuID).ToList();
            return View(managechill);
        }

        public IActionResult Create()
        {
            var adList = (from m in _context.Adminmenus
                          where m.ItemLevel == 1
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuID.ToString()
                          }).ToList();
            adList.Insert(0, new SelectListItem()
            {
                Text = "----select-----",
                Value = String.Empty

            }) ;
            ViewBag.adList = adList;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Adminmenu ad)
        {
            if (ModelState.IsValid)
            {
                _context.Adminmenus.Add(ad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // chỉnh sửa danh mục
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ad = _context.Adminmenus.Find(id);
            if (ad == null)
            {
                return NotFound();
            }
            var adList = (from m in _context.Adminmenus
                          where m.ItemLevel == 1
                          select new SelectListItem()
                          {
                              Text = m.ItemName,
                              Value = m.AdminMenuID.ToString()
                          }).ToList();
            adList.Insert(0, new SelectListItem()
            {
                Text = "----select-----",
                Value = String.Empty

            });
            ViewBag.adList = adList;

            return View(ad);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Adminmenu ad)
        {
            if (ModelState.IsValid)
            {
                _context.Adminmenus.Update(ad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        // Xóa danh mục
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Adminmenus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleMenu = _context.Adminmenus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _context.Adminmenus.Remove(deleMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

