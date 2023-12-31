using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="MenuFooter")]
    public class MenuFooterComponent:ViewComponent
    {
        private Datacontext _context;
        public MenuFooterComponent(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenuF = (from m in _context.Menus
                               where (m.IsActive == true) && (m.Position == 2)
                               orderby m.MenuOrder ascending
                               select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenuF));
        }
    }
}
