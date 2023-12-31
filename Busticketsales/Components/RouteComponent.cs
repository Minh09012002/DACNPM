using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Route")]
    public class RouteComponent:ViewComponent
    {
        private Datacontext _context;
        public RouteComponent(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofRoute = (from r in _context.Routes
                               where (r.IsActive == true) && (r.Status == 1)
                               orderby r.RouteOrder descending
                               select r).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofRoute));
        }
    }
}
