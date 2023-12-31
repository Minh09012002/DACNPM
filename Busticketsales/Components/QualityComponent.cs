using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name = "Quality")]
    public class QualityComponent:ViewComponent
    {
        private Datacontext _context;
        public QualityComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofQuality = (from q in _context.ContactQualities
                                 where (q.IsActive == true) && (q.Status == 1) && (q.Position == 2)
                                 orderby q.ContactOrder descending
                                 select q).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofQuality));
        }
    }
}
