using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_DocConfig
    {
        [Key]
        public int DocConfigID { get; set; }

        [StringLength(2)]
        public string? Category { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string TName { get; set; } = string.Empty;

        [StringLength(255)]
        public string? EName { get; set; } = string.Empty;

        [Required]
        [StringLength(2)]
        public string Prefix { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Number { get; set; } = string.Empty;
    }
}
