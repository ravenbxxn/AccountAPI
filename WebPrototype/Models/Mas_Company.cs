using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPrototype.Models
{
    public class Mas_Company
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string CustCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string Branch { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? CustGroup { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(50)")]
        public string? TaxNumber { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(15)")]
        public string? Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? NameThai { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? NameEng { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TAddress1 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TAddress2 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? EAddress1 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? EAddress2 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(255)")]
        public string? Phone { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(255)")]
        public string? FaxNumber { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? LoginName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? LoginPassword { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? ManagerCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? CSCodeIM { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? CSCodeEX { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? CSCodeOT { get; set; } = string.Empty;
        [Column(TypeName = "varchar(15)")]
        public string? GLAccountCode { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public byte CustType { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string? BillToCustCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? BillToBranch { get; set; } = string.Empty;
        [Column(TypeName = "varchar(2)")]
        public string? UsedLanguage { get; set; } = string.Empty;
        [Column(TypeName = "varchar(5)")]
        public string? LevelGrade { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public byte? TermOfPayment { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? BillCondition { get; set; } = string.Empty;
        [Column(TypeName = "float")]
        public decimal? CreditLimit { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? MapText { get; set; } = string.Empty;
        [Column(TypeName = "varchar(150)")]
        public string? MapFileName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(1)")]
        public string? CmpType { get; set; } = string.Empty;
        [Column(TypeName = "varchar(1)")]
        public string? CmpLevelExp { get; set; } = string.Empty;
        [Column(TypeName = "varchar(1)")]
        public string? CmpLevelImp { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public byte Is19bis { get; set; }
        [Column(TypeName = "smallint")]
        public short MgrSeq { get; set; }
        [Column(TypeName = "int")]
        public int LevelNoExp { get; set; }
        [Column(TypeName = "int")]
        public int LevelNoImp { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? LnNO { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? AdjTaxCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? BkAuthorNo { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? BkAuthorCnn { get; set; } = string.Empty;
        [Column(TypeName = "varchar(70)")]
        public string? LtdPsWkName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)")]
        public string? ConsStatus { get; set; } = string.Empty;
        [Column(TypeName = "varchar(5)")]
        public string? CommLevel { get; set; } = string.Empty;
        [Column(TypeName = "float")]
        public decimal DutyLimit { get; set; }
        [Column(TypeName = "float")]
        public decimal CommRate { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? TAddress { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TDistrict { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TSubProvince { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(255)")]
        public string? TProvince { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(255)")]
        public string? TPostCode { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(255)")]
        public string? DMailAddress { get; set; } = string.Empty;
        [Column(TypeName = "varchar(1)")]
        public string? PrivilegeOption { get; set; } = string.Empty;
        [Column(TypeName = "smallint")]
        public short GoldCardNO { get; set; }
        [Column(TypeName = "smallint")]
        public short CustomsBrokerSeq { get; set; }
        [Column(TypeName = "tinyint")]
        public byte ISCustomerSign { get; set; }
        [Column(TypeName = "tinyint")]
        public byte ISCustomerSignInv { get; set; }
        [Column(TypeName = "tinyint")]
        public byte ISCustomerSignDec { get; set; }
        [Column(TypeName = "tinyint")]
        public byte ISCustomerSignECon { get; set; }
        [Column(TypeName = "tinyint")]
        public byte IsShippingCannotSign { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? ExportCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(15)")]
        public string? Code19BIS { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? WEB_SITE { get; set; } = string.Empty;
    }
}
