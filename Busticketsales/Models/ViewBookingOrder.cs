using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("View_BookingOrder")]
    public class ViewBookingOrder
    {
        [Key]
        public long BookingOrderID { get; set; }
        public long BookingID { get; set; }
        public string? Time { get; set; }
        public string? ArrivalTime { get; set; }
        public string? ProvinceStart { get; set; }
        public string? ProvinceEnd { get; set; }
        public string? ProvinceStarts { get; set; }
        public string? ProvinceEnds { get; set; }
        public string? PointStart { get; set; }
        public string? PointEnd { get; set; }
        public string? Seat { get; set; }
        public string? Price { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? Date { get; set; }
    }
}
