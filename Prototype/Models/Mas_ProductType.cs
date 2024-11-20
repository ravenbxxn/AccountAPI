using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_ProductType
    {
        [Key]
        public int ProductTypeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductTypeCode { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ProductTypeName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string WarehouseCode { get; set; } = string.Empty;

        [Required]
        public bool IsMaterial { get; set; }

        [Required]
        public bool IsService { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal RateVat { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal RateWht { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 1)]
        public string VatType { get; set; } = string.Empty;

    }
}
