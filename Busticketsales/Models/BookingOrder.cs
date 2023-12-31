using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("BookingOrder")]
    public class BookingOrder
    {
        [Key]
        public long BookingOrderID { get; set; }
        public long BookingID { get; set; }
        public string? Time { get; set;}
        public string? ArrivalTime { get; set; }
        public string? ProvinceStart { get; set; }
        public string? ProvinceEnd { get; set; }
        public string? PointStart { get; set; }
        public string? PointEnd { get; set; }
        public int? Seat { get; set; }
        public string? Price { get; set; }
        public bool? IsActive { get; set; }
        public string? ItemTarget { get; set; }
        public string? IdName { get; set; }
        public DateTime? Date { get; set; }
        
    }
}
