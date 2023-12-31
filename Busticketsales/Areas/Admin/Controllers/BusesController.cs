using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusesController : Controller
    {
        private readonly Datacontext _context;
        public BusesController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var bus = _context.BookingOrders.Where(m => m.IsActive == true).ToList();
            return View(bus);
        }

        // thêm mới bus
        public IActionResult Create()
        {
            var bk =  (from b in _context.Bookings.Where(m => m.IsActive == true)
                         select new SelectListItem()
                         {
                             Text = b.ProvinceEnds,
                             Value = b.ProvinceEnds.ToString(),
                         }).ToList();
                        bk.Insert(0, new SelectListItem()
                        {
                            Text = "---- Tỉnh đi-----",
                            Value = "0"
                        });
            ViewBag.bk = bk;

            var bke = (from b in _context.Bookings.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = b.ProvinceEnds,
                           Value = b.ProvinceEnds.ToString(),
                       }).ToList();
            bke.Insert(0, new SelectListItem()
            {
                Text = "---- Tỉnh đến -----",
                Value = "0"
            });
            ViewBag.bke = bke;


            var bks = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                      select new SelectListItem()
                      {
                          Text = b.DetailPointStart,
                          Value = b.DetailPointStart.ToString(),
                      }).ToList();
            bks.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm đi-----",
                Value = "0"
            });
            ViewBag.bks = bks;


            var bkes = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = b.DetailPointEnd,
                           Value = b.DetailPointEnd.ToString(),
                       }).ToList();
            bkes.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm dừng -----",
                Value = "0"
            });
            ViewBag.bkes = bkes;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookingOrder bus)
        {
            if (ModelState.IsValid)
            {
                _context.BookingOrders.Add(bus);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bk = (from a in _context.Bookings.Where(m => m.IsActive == true)
                      select new SelectListItem()
                      {
                          Text = a.ProvinceEnds,
                          Value = a.ProvinceEnds.ToString(),
                      }).ToList();
            bk.Insert(0, new SelectListItem()
            {
                Text = "---- Tỉnh đi-----",
                Value = "0"
            });
            ViewBag.bk = bk;

            var bke = (from a in _context.Bookings.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = a.ProvinceEnds,
                           Value = a.ProvinceEnds.ToString(),
                       }).ToList();
            bke.Insert(0, new SelectListItem()
            {
                Text = "---- Tỉnh đến -----",
                Value = "0"
            });
            ViewBag.bke = bke;


            var bks = (from a in _context.DetailPoints.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = a.DetailPointStart,
                           Value = a.DetailPointStart.ToString(),
                       }).ToList();
            bks.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm đi-----",
                Value = "0"
            });
            ViewBag.bks = bks;


            var bkes = (from a in _context.DetailPoints.Where(m => m.IsActive == true)
                        select new SelectListItem()
                        {
                            Text = a.DetailPointEnd,
                            Value = a.DetailPointEnd.ToString(),
                        }).ToList();
            bkes.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm dừng -----",
                Value = "0"
            });
            ViewBag.bkes = bkes;

            var b = _context.BookingOrders.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookingOrder b)
        {
            if (ModelState.IsValid)
            {
                _context.BookingOrders.Update(b);
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
            var b = _context.BookingOrders.Find(id);
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
            var Deletect = _context.BookingOrders.Find(id);
            if (Deletect == null)
            {
                return NotFound();
            }
            _context.BookingOrders.Remove(Deletect);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
