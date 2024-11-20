using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPrototype.Models
{
    public class Mas_Account
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string AccCode { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? AccTName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? AccEName { get; set; } = string.Empty;

        [Column(TypeName = "int")]
        public int? AccType { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? AccMain { get; set; } = string.Empty;

        [Column(TypeName = "char(1)")]
        public string? AccSide { get; set; } = string.Empty;
    }
}
