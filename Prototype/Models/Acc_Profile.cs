using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{

    public class Acc_Profile
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? THName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? THAddress1 { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? THAddress2 { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(max)")]
        public string? ENName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? EAddress1 { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? EAddress2 { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string? TelPhoneFax { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(100)")]
        public string? ProfileType { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string? TaxNumber { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(10)")]
        public string? Branch { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string? BusRegisNum { get; set; } = string.Empty;
    }
}
