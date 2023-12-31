using Microsoft.AspNetCore.Mvc;
using Busticketsales.Utilities;

namespace RESTORANS.Areas.Admin.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            Functions._UserID = 0;
            Functions._UserName = String.Empty;
            Functions._Email = String.Empty;
            Functions._Messager = String.Empty;
            Functions._MessagerEmail = String.Empty;
            Functions._Images = String.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
