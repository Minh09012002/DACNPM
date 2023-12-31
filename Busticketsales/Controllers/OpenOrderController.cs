using Busticketsales.Models;
using Busticketsales.Utilities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;

namespace Busticketsales.Controllers
{
    public class OpenOrderController : Controller
    {
        private readonly Datacontext _context;
        public OpenOrderController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var views = _context.CustomerOrders.Where(m => m.CustomerID == Functions._UserID).ToList();
            return View(views);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bk = _context.CustomerOrders.Find(id);
            if (bk == null)
            {
                return NotFound();
            }
            _context.CustomerOrders.Remove(bk);
            _context.SaveChanges();
            return RedirectToAction("Index", "OpenOrder");
        }

        /*[HttpPost]
        public IActionResult Delete(long id)
        {
            var DeleteCs = _context.CustomerOrders.Find(id);
            if (DeleteCs == null)
            {
                return NotFound();
            }
            _context.CustomerOrders.Remove(DeleteCs);
            _context.SaveChanges();
            return RedirectToAction("Index", "OpenOrder");
        }*/
    }
}
