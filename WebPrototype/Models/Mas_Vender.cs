using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPrototype.Models
{
    public class Mas_Vender
    {
        [Key]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string VenCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string? BranchCode { get; set; } = string.Empty;
        [Column(TypeName = "varchar(30)")]
        public string? TaxNumber { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(50)")]
        public string? Title { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TName { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? English { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TAddress1 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? TAddress2 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? EAddress1 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? EAddress2 { get; set; } = string.Empty;
        [Column(TypeName = "varchar(30)")]
        public string? Phone { get; set; } = string.Empty;
        [Column(TypeName = "varchar(30)")]
        public string? FaxNumber { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? LoginName { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string? LoginPassword { get; set; } = string.Empty;
        [Column(TypeName = "varchar(15)")]
        public string? GLAccountCode { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? ContactAcc { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? ContactSale { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? ContactSupport1 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? ContactSupport2 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? ContactSupport3 { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        public string? WEB_SITE { get; set; } = string.Empty;
    }
}
