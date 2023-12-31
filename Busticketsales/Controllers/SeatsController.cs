using Busticketsales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Busticketsales.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/seats")]
    public class SeatsController : Controller
    {
        private readonly Datacontext _context;

        public SeatsController(Datacontext context)
        {
            _context = context;
        }

        [HttpGet("sold")]
        public async Task<ActionResult<IEnumerable<CustomerOrder>>> GetSoldSeats()
        {
            var soldSeats = await _context.CustomerOrders.Where(s => s.IsActive == true).ToListAsync();
            return soldSeats;
        }
    }
}
