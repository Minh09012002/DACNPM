
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("CustomerOrder")]
    public class CustomerOrder
    {
        [Key]
        public long CustomerOrderID { get; set; }
        public long BookingOrderID { get; set; }
        public string? FullName { get; set; }
        public string? SĐT { get; set; }
        public string? Email { get; set; }
        public string? PointStrDetail { get; set; }
        public string? PointEndDetail { get; set; }
        public string? ProvinceStr { get; set; }
        public string? ProvinceEnd { get; set; }
        public string? Seat { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public int? Status { get; set; }
        public int? CustomerID { get; set; }
        public string? time { get; set; }
        public string? TotalPrice { get; set; }

    }
}
