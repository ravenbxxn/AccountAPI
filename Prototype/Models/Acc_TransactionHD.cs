using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Acc_TransactionHD
    {
        [Key]
        [StringLength(50)]
        public string AccDocNo { get; set; } = string.Empty;

        public DateTime AccBatchDate { get; set; }

        public DateTime AccEffectiveDate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string PartyCode { get; set; } = string.Empty;

        [StringLength(13, MinimumLength = 13)]
        public string? PartyTaxCode { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string PartyName { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string PartyAddress { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string IssueBy { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string AccDocType { get; set; } = string.Empty;

        public DateTime AccPostDate { get; set; }

        public DateTime FiscalYear { get; set; }

        public int  DocStatus { get; set; }

        [StringLength(50)]
        public string? DocRefNo { get; set; }
    }
}
