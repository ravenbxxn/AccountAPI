using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_SrvSingle
    {
        [Key]
        [Required]
        [Column(TypeName ="varchar(10)")]
        public string SICode { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? NameThai { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? NameEng { get; set; } = string.Empty;

        [Column(TypeName = "float")]
        public decimal? StdPrice { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? UnitCharge { get; set; } = string.Empty;

        [Column(TypeName = "varchar(3)")]
        public string? CurrencyCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string? DefaultVender { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? ProcessDesc { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string? GLAccountCodeSales { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string? GLAccountCodeCost { get; set; } = string.Empty;

        [Column(TypeName = "tinyint")]
        public byte IsTaxCharge { get; set; }

        [Column(TypeName = "tinyint")]
        public byte Is50Tavi { get; set; }

        [Column(TypeName = "float")]
        public decimal Rate50Tavi { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsCredit { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsExpense { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsShowPrice { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsHaveSlip { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsPay50TaviTo { get; set; }

        [Column(TypeName = "tinyint")]
        public byte IsLtdAdv50Tavi { get; set; }

        [Column(TypeName = "int")]
        public int IsUsedCoSlip { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? GroupCode { get; set; } = string.Empty;

    }
}
