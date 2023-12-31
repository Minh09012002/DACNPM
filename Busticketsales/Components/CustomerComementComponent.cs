using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name = "CustomerComment")]
    public class CustomerCommentComponent : ViewComponent
    {
        private readonly Datacontext _context;
        public CustomerCommentComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofComment = (from item in _context.CustomerComments
                                 where (item.IsActive == true) && (item.Status == 1)
                                 orderby item.CommentID descending
                                 select item).FirstOrDefault();

            return await Task.FromResult((IViewComponentResult)View("Default", listofComment));
        }
    }
}

