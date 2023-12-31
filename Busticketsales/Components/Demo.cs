using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name = "Demo")]
    public class Demo : ViewComponent
    {
        private readonly Datacontext _context;
        public Demo(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofComment = (from item in _context.CustomerOrders
                                 where (item.IsActive == true) && (item.Status == 1)
                                 orderby item.CustomerOrderID descending
                                 select item).FirstOrDefault();

            return await Task.FromResult((IViewComponentResult)View("Default", listofComment));
        }
    }
}
