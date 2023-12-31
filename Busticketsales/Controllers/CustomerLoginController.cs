using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Busticketsales.Utilities;

namespace Busticketsales.Controllers
{
    public class CustomerLoginController : Controller
    {
        private readonly Datacontext _context;
        public CustomerLoginController(Datacontext context)
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
            // mã hóa mật khẩu trước khi kiểm tra
            string pw = Functions.MD5Password(user.Password);
            // kiểm tra sự tồn tại của email trong cơ sở dữ liệu
            var check = _context.Customers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                // hiển thị thông báo có thể làm cách khác

                Functions._Messager = "Lỗi Email hoặc Password !";
                return RedirectToAction("Index", "CustomerLogin");
            }
            // vào  nếu đúng use và mật khẩu nó sẽ load lên tài khoản
            Functions._Messager = string.Empty;
            Functions._UserID =check.CustomerID;
            Functions._Password = string.IsNullOrEmpty(check.Password) ? string.Empty : check.Password;
            Functions._FullName = string.IsNullOrEmpty(check.FullName) ? string.Empty : check.FullName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            Functions._SĐT = string.IsNullOrEmpty(check.SĐT) ? string.Empty : check.SĐT;
            Functions._Images = string.IsNullOrEmpty(check.Images) ? string.Empty : check.Images;

            return RedirectToAction("Index", "Home");
        }
    }
}
