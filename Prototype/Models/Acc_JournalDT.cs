using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Acc_JournalDT
    {
        [Required]
        public int EntryId { get; set; }

        [Required]
        public int Seq { get; set; }

        [StringLength(50)]
        public string? AccCode { get; set; }

        [StringLength(255)]
        public string? AccName { get; set; }

        [MaxLength]
        public string? AccDesc { get; set; }

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? Debit { get; set; }

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? Credit { get; set; }
    }
}
