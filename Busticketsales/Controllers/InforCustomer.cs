using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Busticketsales.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Busticketsales.Controllers
{
   
    public class InforCustomer : Controller
    {
        private readonly Datacontext _context;
        public InforCustomer(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var inf = _context.Customers.Where(m => m.CustomerID == Functions._UserID).FirstOrDefault();
            return View(inf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer mn, string PasswordNew)
        {
            if (mn == null)
            {
                return NotFound();
            }
            // mã hoá mật khẩu trc khi kiểm tra
            string pw = Functions.MD5Password(mn.Password);
            if (Functions._Password != pw)
            {
                Functions._Messager = "Mật khẩu cũ chưa đúng!";
                return RedirectToAction("Index", "InforCustomer");
            }
            // mã hóa mật khẩu trước khi lưu
            Functions._MessagerEmail = string.Empty;
            mn.Password = Functions.MD5Password(PasswordNew);

            _context.Update(mn);
            _context.SaveChanges();
            return RedirectToAction("Index", "CustomerLogout");
        }
    }
}
