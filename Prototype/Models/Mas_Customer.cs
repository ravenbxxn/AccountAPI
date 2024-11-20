using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CustomerCode { get; set; } = null!;

        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string TaxNumber { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string TaxBranch { get; set; } = null!;

        [Required]
        [StringLength(9999, MinimumLength = 3)]
        public string CustomerName { get; set; } = null!;

        [StringLength(9999)]
        public string? CustomerEName { get; set; }

        [Required]
        [StringLength(9999, MinimumLength = 3)]
        public string Address1 { get; set; } = null!;

        [StringLength(9999)]
        public string? Address2 { get; set; }

        [StringLength(9999)]
        public string? EAddress1 { get; set; }

        [StringLength(9999)]
        public string? EAddress2 { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }

        [StringLength(30)]
        public string? FaxNumber { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(255)]
        public string? Contact { get; set; }

        [StringLength(255)]
        public string? WebLink { get; set; }

        [StringLength(5)]
        public string? CountryCode { get; set; }

        [StringLength(50)]
        public string? ZIPCode { get; set; }

        [StringLength(50)]
        public string? GLAccountCode { get; set; }
    }
}
