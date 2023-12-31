using Busticketsales.Areas.Admin.Models;
using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Busticketsales.Utilities;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly Datacontext _context;
        public AdminUserController(Datacontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           var user = _context.AdminUsers.Where(m=>m.IsActive == true).OrderBy(m=>m.UserID).ToList();
            return View(user);
        }
/*
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            // kiểm tra sự tồn tại của email  trong cơ sở dữ liệu
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                // hiển thị thông báo có thể làm cách khác

                Functions._MessagerEmail = "Trùng Email!";
                return RedirectToAction("Index", "Register");


            }
            // nếu không có thì thêm vào cơ sở dữ liệu
            Functions._MessagerEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }*/

        // xem chi tiết tài khoản
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.AdminUsers
                        .FirstOrDefault(m => (m.UserID == id) && (m.IsActive == true));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Xóa tài khoản khách hàng
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var user = _context.AdminUsers.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.AdminUsers.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.AdminUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
