using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HRPosition
    {
        [Key]
        public int PositionId { get; set; }

        [StringLength(255)]
        public string? PositionName { get; set; }

        [StringLength(255)]
        public string? PositionNameEN { get; set; }

        public int? LevelId { get; set; }

        public int? DepartmentId { get; set; }
    }
}
