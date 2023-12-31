using Busticketsales.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // thêm 2 lệnh sau vào các action của các controller  để kiểm tra trạng thái đăng nhập
            if(!Functions.IsLogin())
             return RedirectToAction("Index", "Login");
            return View();
        }
    }
}
