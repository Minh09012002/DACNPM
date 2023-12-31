using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Areas.Admin.Components
{
    [ViewComponent(Name = "Overview")]
    public class Overview : ViewComponent
    {
        private readonly Datacontext _context;
        public Overview(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var listnoti = (from m in _context.CustomerOrders
                            where (m.Status == 1)
                            select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listnoti));
        }
    }
}
