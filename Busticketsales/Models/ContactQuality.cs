using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("ContactQuality")]
    public class ContactQuality
    {
        [Key]
        public long ContactQualityID { get; set; }
        public string? Images { get; set; }
        public string? Title { get; set; }
        public string? Phone { get; set; }
        public bool? IsActive { get; set; }
        public int Status { get; set;}
        public int ContactOrder { get; set; }
        public int Position { get; set; }
        public string? Description { get; set; }
    }
}
