using Busticketsales.Models;
using Busticketsales.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerOrderController : Controller
    {
        private readonly Datacontext _context;
        public CustomerOrderController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var order =  _context.CustomerOrders.Where(m => m.IsActive == true).ToList();
            return View(order);
        }

        public IActionResult Create()
        {

            var bk = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                      select new SelectListItem()
                      {
                          Text = b.DetailPointStart,
                          Value = b.DetailPointStart.ToString(),
                      }).ToList();
            bk.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm Đón-----",
                Value = string.Empty
            });
            ViewBag.bk = bk;

            var bke = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = b.DetailPointEnd,
                           Value = b.DetailPointEnd.ToString(),
                       }).ToList();
            bke.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm Trả-----",
                Value = string.Empty
            });
            ViewBag.bke = bke;

          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string sdt, string Name, string Email, string PointStr, string PointEnd, string ProvinceStr, string ProvinceEnd, string Seat, int Status, DateTime Date, string Time, int UserID)
        {
            var DetailBooking = new CustomerOrder
            {
                SĐT = sdt,
                FullName = Name,
                Email = Email,
                PointStrDetail = PointStr,
                PointEndDetail = PointEnd,
                ProvinceStr = ProvinceStr,
                ProvinceEnd = ProvinceEnd,
                Date = Date,
                Status = Status,
                Seat = Seat,
                IsActive = true,
                CreateDate = DateTime.Now,
                time = Time,
                CustomerID = UserID

            };
            _context.CustomerOrders.Add(DetailBooking);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(long?id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.CustomerOrders.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var bk = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                      select new SelectListItem()
                      {
                          Text = b.DetailPointStart,
                          Value = b.DetailPointStart.ToString(),
                      }).ToList();
            bk.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm Đón-----",
                Value = string.Empty
            });
            ViewBag.bk = bk;

            var bke = (from b in _context.DetailPoints.Where(m => m.IsActive == true)
                       select new SelectListItem()
                       {
                           Text = b.DetailPointEnd,
                           Value = b.DetailPointEnd.ToString(),
                       }).ToList();
            bke.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm Trả-----",
                Value = string.Empty
            });
            ViewBag.bke = bke;


            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long CustomerOrderID, long BookingOrderID, string sdt, string Name, string Email, string PointStr, string PointEnd, string ProvinceStr, string ProvinceEnd, string Seat, int Status, DateTime Date, string Time, int CustomerID, string TotalPrice)
        {
            var DetailBooking = new CustomerOrder
            {
                CustomerOrderID = CustomerOrderID,
                SĐT = sdt,
                FullName = Name,
                Email = Email,
                PointStrDetail = PointStr,
                PointEndDetail = PointEnd,
                ProvinceStr = ProvinceStr,
                ProvinceEnd = ProvinceEnd,
                Date = Date,
                Status = Status,
                Seat = Seat,
                IsActive = true,
                CreateDate = DateTime.Now,
                time = Time,
                CustomerID = CustomerID,
                BookingOrderID = BookingOrderID,
                TotalPrice = TotalPrice
               

            };

            _context.CustomerOrders.Update(DetailBooking);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
           
            var ctm = _context.CustomerOrders.Find(id);
            if (ctm == null)
            {
                return NotFound();
            }
            return View(ctm);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var Deletectm = _context.CustomerOrders.Find(id);
           
            if (Deletectm == null)
            {
                return NotFound();
            }
            _context.CustomerOrders.Remove(Deletectm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ctm = _context.CustomerOrders
                        .FirstOrDefault(m => (m.CustomerOrderID == id) && (m.IsActive == true));
            if (ctm == null)
            {
                return NotFound();
            }
            return View(ctm);
        }

        
    }
}
