using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public long ServiceID { get; set; }
        public string? Images { get; set; }
        public string? ServiceName { get; set; }
        public string? ServiceDesc { get; set; }
        public bool? IsActive { get; set; }
        public int Status { get; set; }
        public int ServiceOrder { get; set; }
        public int LeftRight { get; set; }
    }
}
