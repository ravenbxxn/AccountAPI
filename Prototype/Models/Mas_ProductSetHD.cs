using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_ProductSetHD
    {
        [Key]
        public int ProductSetHDID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductSetCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? PromoCode { get; set; } = string.Empty;

        [StringLength(50)]
        public string? UnitStock { get; set; } = string.Empty;

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal SalesPrice { get; set; }

        [StringLength(10)]
        public string? SalesCurrency { get; set; } = string.Empty;

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public decimal SalesRate { get; set; }

        [StringLength(10)]
        public string? IncomeAccCode { get; set; } = string.Empty;

        [StringLength(10)]
        public string? ExpenseAccCode { get; set; } = string.Empty;

    }
}
