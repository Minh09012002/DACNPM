using Busticketsales.Models;
using Busticketsales.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Busticketsales.Controllers
{
    public class DemoController : Controller
    {
       private readonly Datacontext _context;
       public DemoController(Datacontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var bookingOrders = _context.BookingOrders.Where(m => m.IsActive == true).ToList();
            var customerOrders = _context.CustomerOrders.Where(m => m.IsActive == true).ToList();
           

            if (customerOrders != null)
            {
                // Tạo đối tượng Tuple
                
                var tupleModel = new Tuple<IList<BookingOrder>, List<CustomerOrder>>( bookingOrders, customerOrders);
                return View(tupleModel);
            }
            else
            {
                // Xử lý khi customerOrder là NULL
                // Điều này có thể làm gì đó phù hợp với ứng dụng của bạn
                return NotFound(); // Hoặc trả về một trang lỗi, hoặc redirect, tùy thuộc vào yêu cầu của bạn
            }
        }
    }
}
