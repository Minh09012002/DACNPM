
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("DetailPoint")]
    public class DetailPoint
    {
        [Key]
        public int DetailPointID { get; set; }
        public string? DetailPointStart { get; set; }
        public string? DetailPointEnd { get; set; }
        public string? Time { get; set; }
        public bool? IsActive { get; set; }
    }
}
