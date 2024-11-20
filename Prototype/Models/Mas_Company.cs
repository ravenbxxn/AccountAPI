using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_Company
    {
        [Key]
        public int CompanyId { get; set; }

        [StringLength(50)]
        public string? CompanyTaxId { get; set; }

        [StringLength(5)]
        public string? CompanyTaxBranch { get; set; }

        [StringLength(255)]
        public string? CompanyName { get; set; }

        [StringLength(255)]
        public string? CompanyNameEN { get; set; }

        public int? HeadCompanyId { get; set; }

        [StringLength(5)]
        public string? CountryCode { get; set; }
    }
}
