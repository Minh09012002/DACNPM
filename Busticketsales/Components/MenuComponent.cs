using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Menu")]
    public class MenuComponent:ViewComponent
    {
        private Datacontext _context;
        public MenuComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
