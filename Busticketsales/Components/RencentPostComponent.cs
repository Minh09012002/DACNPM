using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="RencentPost")]
    public class RencentPostComponent:ViewComponent
    {
        private Datacontext _context;
        public RencentPostComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofRenc = (from m in _context.Posts
                              where (m.IsActive == true) && (m.Status == 1)
                              orderby m.PostOrder
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofRenc));
        }
    }
}
