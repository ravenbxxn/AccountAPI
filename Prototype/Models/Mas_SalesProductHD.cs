using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_SalesProductHD
    {
        [Key]
        public int SalesProductIDHD { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string SalesProductCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string SalesProductName { get; set; } = string.Empty;

        [Required]
        public DateTime BeginSalesDate { get; set; }

        [Required]
        public DateTime EndSalesDate { get; set; }
    }
}
