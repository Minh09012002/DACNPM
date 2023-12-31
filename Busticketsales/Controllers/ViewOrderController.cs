using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Busticketsales.Utilities;

namespace Busticketsales.Controllers
{
    public class ViewOrderController : Controller
    {
        private readonly Datacontext _context;
        public ViewOrderController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var views = _context.CustomerOrders.Where(m => m.CustomerOrderID == Functions._UserID).ToList();
            return View(views);
        }
    }
}
