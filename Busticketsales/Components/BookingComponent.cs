using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Busticketsales.Components
{
    [ViewComponent(Name ="Booking")]
    public class BookingComponent:ViewComponent
    {
        private Datacontext _context;
        public BookingComponent(Datacontext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var booking = (from b in _context.Bookings
                           where (b.IsActive == true) && (b.Status == 1)
                           orderby b.BookingOrder
                           select b).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", booking));
        }
    }
}
