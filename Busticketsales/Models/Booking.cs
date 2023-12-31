using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public long BookingID { get; set;}
        public string? ProvinceStarts { get; set;}
        public string? ProvinceEnds { get; set; }
        public bool? IsActive { get; set; }
        public int Status { get; set;}
        public int BookingOrder { get; set; }
    }
}
