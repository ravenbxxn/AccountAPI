using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_ProductSetDT
    {
        [Key]
        public int ProductSetDTID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductSetCode { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int ItemNo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [Range(0, int.MaxValue)]
        public int Qty { get; set; }

        [StringLength(50)]
        public string? UnitStock { get; set; } = string.Empty;
    }
}
