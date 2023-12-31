using Microsoft.AspNetCore.Mvc;
using Busticketsales.Utilities;

namespace RESTORANS.Controllers
{
    public class CustomerLogout : Controller
    {
        public IActionResult Index()
        {
            Functions._UserID = 0;
            Functions._FullName= String.Empty;
            Functions._Email = String.Empty;
            Functions._SĐT= String.Empty;
            Functions._Messager = String.Empty;
            Functions._MessagerEmail = String.Empty;
            Functions._Images = String.Empty;

            return RedirectToAction("Index", "Home");
        }

    }
}
