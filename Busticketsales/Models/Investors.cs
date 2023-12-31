using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("Investors")]
    public class Investors
    {
        [Key]
        public long InvestorsID { get; set; }
        public string? Images { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
    }
}
