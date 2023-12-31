using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Service")]
    public class ServiceComponent:ViewComponent
    {
        private Datacontext _context;
        public ServiceComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofService = (from s in _context.Services
                                 where (s.IsActive == true) && (s.Status == 1)
                                 orderby s.ServiceOrder descending
                                 select s).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofService));
        }
    }
}
