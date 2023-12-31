using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly Datacontext _context;
        public CustomerController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customer = _context.Customers.OrderBy(m => m.CustomerID).ToList();
            return View(customer);
        }

        // xem chi tiết tài khoản
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Customer = _context.Customers
                        .FirstOrDefault(m => (m.CustomerID == id) && (m.IsActive == true));
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        // Xóa tài khoản khách hàng
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {


            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
