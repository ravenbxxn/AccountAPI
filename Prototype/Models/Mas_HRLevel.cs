using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HRLevel
    {
        [Key]
        public int LevelId { get; set; }

        [StringLength(50)]
        public string? LevelName { get; set; }

        [StringLength(50)]
        public string? LevelNameEN { get; set; }
    }
}
