using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Acc_TransactionDT
    {
        
        [StringLength(50)]
        public string AccDocNo { get; set; } = null!;

        [Required]
        public int AccItemNo { get; set; }

        [StringLength(50)]
        public string? AccSourceDocNo { get; set; }

        public int? AccSourceDocItem { get; set; }

        [Required]
        public int StockTransNo { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitMea { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Currency { get; set; } = null!;

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public double ExchangeRate { get; set; }

        [Required]
        [Range(0.0, (double)decimal.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string SaleProductCode { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string SalesDescription { get; set; } = null!;
    }
}
