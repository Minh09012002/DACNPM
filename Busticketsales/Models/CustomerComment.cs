using Busticketsales.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Busticketsales.Models
{
    [Table("CustomerComment")]
    public class CustomerComment
    {
        [Key]
        public long CommentID { get; set; }
        public string? Images { get; set; }
        public string? Content { get; set; }
        public string? FullName { get; set; }
        public bool? IsActive { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }


    }
}
