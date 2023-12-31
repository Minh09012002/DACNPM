using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Controllers
{
    public class NoBusController : Controller
    {
        private readonly Datacontext _context;
        public NoBusController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
