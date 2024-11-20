using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Acc_StockTransaction
    {
        [Key]
        public int TransID { get; set; }

        public string TransNum { get; set; } = string.Empty;

        [Required]
        public string TransType { get; set;} = string.Empty;

        [Required]
        public string StockProductCode { get; set; } = string.Empty;

        [Required]
        public int TransQty { get; set; }

        [Required]
        [Range((double)decimal.MinValue, (double)decimal.MaxValue)]
        public decimal TransPrice { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string TransCurrency { get; set; } = string.Empty;

        [Required]
        [Range((double)decimal.MinValue, (double)decimal.MaxValue)]
        public decimal TransRate { get; set; }

        [StringLength(10)]
        public string? AssetAccCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string WarehouseCode { get; set; } = string.Empty;

        [StringLength(50)]
        public string? RefDocNo { get; set; } = string.Empty;

    }
}
