using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Busticketsales.Models;
using Busticketsales.Utilities;

namespace Busticketsales.Controllers
{
    public class CustomerRegisterController : Controller
    {

        private readonly Datacontext _context;
        public CustomerRegisterController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Customer user)
        {
            if (user == null)
            {
                return NotFound();
            }
            // kiểm tra sự tồn tại của email  trong cơ sở dữ liệu
            var check = _context.Customers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                // hiển thị thông báo có thể làm cách khác

                Functions._MessagerEmail = "Trùng Email!";
                return RedirectToAction("Index", "CustomerRegister");


            }
            // nếu không có thì thêm vào cơ sở dữ liệu
            Functions._MessagerEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "CustomerLogin");
        }
    }
}
