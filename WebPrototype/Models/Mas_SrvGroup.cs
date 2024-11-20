using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPrototype.Models
{
    public class Mas_SrvGroup
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string GroupCode { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? GroupName { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string? GLAccountCode { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int? IsApplyPolicy { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? IsTaxCharge { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? Is50Tavi { get; set; }

        [Column(TypeName = "float")]
        public decimal? Rate50Tavi { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? IsCredit { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? IsExpense { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? IsHaveSlip { get; set; }

        [Column(TypeName = "tinyint")]
        public byte? IsLtdAdv50Tavi { get; set; }
    }
}
