using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_AccType
    {
        [Key]
        public int AccTypeID { get; set; }

        [StringLength(10)]
        public string? AccType { get; set; }

        [StringLength(255)]
        public string? AccTypeName { get; set; }

        [StringLength(255)]
        public string? AccTypeNameEn { get; set; }

        [StringLength(1)]
        public string? AccSide { get; set; }
    }
}
