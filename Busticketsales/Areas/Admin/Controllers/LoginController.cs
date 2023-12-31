using Microsoft.AspNetCore.Mvc;
using Busticketsales.Areas.Admin.Models;
using Busticketsales.Models;
using Busticketsales.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RESTORANS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly Datacontext _context;
        public LoginController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            // mã hóa mật khẩu trước khi kiểm tra
            string pw = Functions.MD5Password(user.Password);
            // kiểm tra sự tồn tại của email trong cơ sở dữ liệu
            var check = _context.AdminUsers.Where(m => (m.Email == user.Email) && (m.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                // hiển thị thông báo có thể làm cách khác

               Functions._Messager = "Lỗi Email hoặc Password !";
                return RedirectToAction("Index", "Login");
            }
            // vào trang admin nếu đúng use và mật khẩu 
            Functions._Messager = string.Empty;
            Functions._UserID = check.UserID;
            Functions._UserName = string.IsNullOrEmpty(check.UserName) ? string.Empty : check.UserName;
            Functions._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            Functions._Images = string.IsNullOrEmpty(check.Images) ? string.Empty : check.Images;
            return RedirectToAction("Index", "Home");
        }
    }
}
