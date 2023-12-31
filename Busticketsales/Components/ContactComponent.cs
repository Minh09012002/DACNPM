using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Contact")]
    public class ContactComponent:ViewComponent
    {
        private Datacontext _context;
        public ContactComponent(Datacontext context)
        {
            _context = context;
        }   
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofContact = (from c in _context.ContactQualities
                                 where (c.IsActive == true) && (c.Status == 1) &&(c.Position == 1)
                                 orderby c.ContactOrder descending
                                 select c).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofContact));
        }
    }
}
