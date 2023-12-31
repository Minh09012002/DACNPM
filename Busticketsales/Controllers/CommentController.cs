using Busticketsales.Models;
using Busticketsales.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Busticketsales.Controllers
{
    public class CommentController : Controller
    {
        private readonly Datacontext _context;
        public CommentController(Datacontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(CustomerComment comment)
        {
            // kiểm tra đăng nhập trước khi bình luận

            if (!Functions.IsLoginweb())
            {
                return RedirectToAction("Index", "CustomerLogin");
            }
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                _context.CustomerComments.Add(comment);
                _context.SaveChanges();

            }
            return RedirectToAction("Index", "Home");
        }
    }
}
