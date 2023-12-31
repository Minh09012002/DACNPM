using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace Busticketsales.Controllers
{
    public class BookingOrderController : Controller
    {
        private readonly Datacontext _context;
        public BookingOrderController(Datacontext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Index(string Ps, string Pe, DateTime date)
        {
            
            var booking = _context.BookingOrders.Where(m=>(m.Date == date) && (m.ProvinceStart == Ps) && (m.ProvinceEnd == Pe)).ToList();
            if(booking.IsNullOrEmpty())
            {
                return RedirectToAction("Index", "NoBus");
            }

            var bk = (from b in _context.BookingOrders.Where(m => m.IsActive == true)
                      select new SelectListItem()
                      {
                          Text = b.PointStart,
                          Value = b.BookingOrderID.ToString(),
                      }).ToList();
            bk.Insert(0, new SelectListItem()
            {
                Text = "---- Điểm Đón-----",
                Value = "0"
            });
            ViewBag.bk = bk;
            return View(booking);
        }

    }
}
