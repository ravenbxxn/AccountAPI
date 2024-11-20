using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_ModuleMenu
    {
        [Required]
        [StringLength(50)]
        public string ModuleID { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string MenuID { get; set; } = null!;

        [StringLength(500)]
        public string? MenuName { get; set; }

        [StringLength(500)]
        public string? MenuNameEN { get; set; }

        [StringLength(500)]

        public string? WebAddress { get; set; }

        [StringLength(50)]
        public string? HeadMenuID { get; set; }

        public int? Seq { get; set; }
    }
}
