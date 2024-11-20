using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_Module
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ModuleID { get; set; } = null!;

        [StringLength(500)]
        public string? ModuleName { get; set; }

        [StringLength(500)]
        public string? ModuleNameEN { get; set; }
    }
}
