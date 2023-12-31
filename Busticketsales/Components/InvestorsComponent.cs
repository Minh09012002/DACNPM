using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Investors")]
    public class InvestorsComponent:ViewComponent
    {
        private Datacontext _context;
        public InvestorsComponent(Datacontext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofInvestors = (from i in _context.Investors
                                   where (i.IsActive == true) && (i.Status == 1)
                                   orderby i.InvestorsID descending
                                   select i).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofInvestors));
        }
    }
}
