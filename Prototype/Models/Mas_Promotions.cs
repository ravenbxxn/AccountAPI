using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_Promotions
    {
        [Key]
        public int PromoCodeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string PromoCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string PromoName { get; set; } = string.Empty;

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal PercentDiscountRate { get; set; }

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal DiscountCash { get; set; }

        [StringLength(10)]
        public string? ExpenseAccCode { get; set; } = string.Empty; 
    }
}
