using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_SalesProductDT
    {
        [Key]
        public int SalesProductIDDT { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string SalesProductCode { get ; set; } = string.Empty;

        [Required]
        public int SalesItemNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductSetCode { get; set; } = string.Empty;

        [Required]
        public int TargetQty { get; set; } 
    }
}
