using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name = "LoadComment")]
    public class LoadCommentComponent : ViewComponent
    {
        private readonly Datacontext _context;
        public LoadCommentComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofComment = (from item in _context.CustomerComments
                                 where (item.IsActive == true) && (item.Status == 1)
                                 orderby item.CommentID descending
                                 select item).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofComment));
        }
    }
}

