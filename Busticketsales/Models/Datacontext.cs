using Busticketsales.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Busticketsales.Models
{
    public class Datacontext:DbContext
    {
       public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ContactQuality> ContactQualities { get; set; }
        public DbSet<Investors> Investors { get; set; }
        public DbSet<ViewPostMenu> ViewPostMenus { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Adminmenu> Adminmenus { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }
        public DbSet<ViewBookingOrder> viewBookingOrders { get; set; }
        public DbSet<DetailPoint> DetailPoints { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerComment> CustomerComments { get; set; }

    }
}
