using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? FullName { get; set; }
        public bool? IsActive { get; set; }
        public int CustomerOrder { get; set; }
        public string? Password { get; set; }
        public string? Images { get; set; }
        public string? Email { get; set; }
        public string? SĐT { get; set; }
    }
}
