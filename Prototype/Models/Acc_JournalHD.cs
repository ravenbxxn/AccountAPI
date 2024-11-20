using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Acc_JournalHD
    {
        [Key]
        public int EntryId { get; set; }

        [StringLength(50)]
        public string? JournalNo { get; set; }

        public DateTime? EntryDate { get; set; }

        public DateTime? EffectiveDate { get; set; }

        [StringLength(50)]
        public string? EntryBy { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? TotalDebit { get; set; }

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? TotalCredit { get; set; }
    }
}
