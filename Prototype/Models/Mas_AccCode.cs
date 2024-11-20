using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_AccCode
    {
        [Key]
        [StringLength(50, MinimumLength = 3)]
        public string AccCode { get; set; } = null!;

        [StringLength(255)]
        public string? AccName { get; set; }

        [StringLength(255)]
        public string? AccNameEn { get; set; }

        public int? AccTypeID { get; set; }

        [StringLength(50)]
        public string? AccMainCode { get; set; }
    }
}
