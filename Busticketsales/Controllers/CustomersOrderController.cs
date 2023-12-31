using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using Busticketsales.Utilities;

namespace Busticketsales.Controllers
{
    public class CustomersOrderController : Controller
    {
        private readonly Datacontext _context;
        public CustomersOrderController(Datacontext context)
        {
            _context = context;
        }

        // tạo public đếm số lượng thông báo
        [HttpGet]
        public IActionResult GetLatestOrders()
        {
            var latestOrders = _context.CustomerOrders.OrderBy(o => o.CreateDate).Take(3).ToList();
            return Ok(latestOrders);
        }



        [HttpPost]
        public IActionResult Index(string Ps, string Pe, DateTime date)
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
                Value = "0"
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
                Value = "0"
            });
            ViewBag.bke = bke;

            var bookingOrders = _context.BookingOrders.Where(m => (m.Date == date) && (m.ProvinceStart == Ps) && (m.ProvinceEnd == Pe)).ToList();
            if (bookingOrders.IsNullOrEmpty())
            {
                return RedirectToAction("Index", "NoBus");
            }

            // tô màu cho ghế ngồi 

            var customerOrders = _context.CustomerOrders.Where(m => m.IsActive == true).ToList();

            var tupleModel = new Tuple<IList<BookingOrder>, List<CustomerOrder>>(bookingOrders, customerOrders);
            return View(tupleModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(long BookingOrderID, string sdt, string Name, string Email, string PointStr, string PointEnd, string ProvinceStr, string ProvinceEnd, string Seat, int Status, DateTime Date, string Time, int UserID,string TotalPrice)
        {
            // kiểm tra khách hàng đăng nhập trước khi đặt v
            if (!Functions.IsLoginweb())
                return RedirectToAction("Index", "CustomerLogin");

            var DetailBooking = new CustomerOrder
            {
                BookingOrderID = BookingOrderID,
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
                CustomerID = UserID,
                TotalPrice = TotalPrice

            };
            _context.CustomerOrders.Add(DetailBooking);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

    }

}
