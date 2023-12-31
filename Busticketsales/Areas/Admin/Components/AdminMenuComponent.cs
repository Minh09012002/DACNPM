using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Areas.Admin.Components
{
    [ViewComponent(Name ="AdminMenu")]
    public class AdminMenuComponent:ViewComponent
    {
        private readonly Datacontext _context;
        public AdminMenuComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnlist = (from mn in _context.Adminmenus
                          where (mn.IsActive == true)
                          select mn).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", mnlist));
        }
    }
}
