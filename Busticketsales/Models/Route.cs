using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("Route")]
    public class Route
    {
        [Key]
        public long RouteID { get; set; }
        public bool IsActive { get; set; }
        public string? Images { get; set; }
        public string? PointOfDe { get; set; }
        public string? StopPoint { get; set; }
        public int Status { get; set; }
        public int RouteOrder { get; set; }
        public string? Price { get; set; }
    }
}
