using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Areas.Admin.Components
{
    [ViewComponent(Name ="Notification")]
    public class NotificationComponent:ViewComponent
    {
        private readonly Datacontext _context;
        public NotificationComponent(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var listnoti = (from m in _context.CustomerOrders
                            where (m.Status == 1) 
                            orderby m.CreateDate descending
                            select m).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listnoti));
        }
    }
}
