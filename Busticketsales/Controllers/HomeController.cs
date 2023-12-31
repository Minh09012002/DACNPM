using Busticketsales.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace Busticketsales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Datacontext _context;

        public HomeController(ILogger<HomeController> logger, Datacontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /* Action Detaile*/
        [Route("/post-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts
                    .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [Route("/list-{slug}-{id:int}.html", Name = "List")]
        public IActionResult List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var list = _context.ViewPostMenus
                    .Where(m => (m.MenuID == id) && (m.IsActive == true))
                    .ToList();
            if(list.IsNullOrEmpty())
            {
                return RedirectToAction("Index", "Home");
            }
            if (list == null )
            {
                return NotFound();
            }
            return View(list);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}