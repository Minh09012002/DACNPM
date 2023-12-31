using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Post")]
    public class PostComponent:ViewComponent
    {
        private Datacontext _context;
        public PostComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from m in _context.Posts
                              where (m.IsActive == true) && (m.Status == 1)
                              orderby m.PostOrder
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
