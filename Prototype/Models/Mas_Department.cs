using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_Department
    {
        [Key]
        public int DPID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string DPCODE { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TShortName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? EShortName { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string TFullName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? EFullName { get; set;} = string.Empty;

        [StringLength(50)]
        public string? Department { get; set; } = string.Empty;

    }
}
