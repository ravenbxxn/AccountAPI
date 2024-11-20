using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_DocConfigSchema
    {
        [Required]
        public int DocConfigID { get; set; }

        [Required]
        public int ConfigType { get; set; }

        [StringLength(500)]
        public string? Field1 { get; set; }

        [StringLength(500)]
        public string? Field2 { get; set; }

        [StringLength(500)]
        public string? Field3 { get; set; }

        [StringLength(500)]
        public string? Field4 { get; set; }

        [StringLength(500)]
        public string? Field5 { get; set; }

        [StringLength(500)]
        public string? Field6 { get; set; }

        [StringLength(500)]
        public string? Field7 { get; set; }

        [StringLength(500)]
        public string? Field8 { get; set; }

        [StringLength(500)]
        public string? Field9 { get; set; }

        [StringLength(500)]
        public string? Field10 { get; set; }

        [StringLength(500)]
        public string? Field11 { get; set; }

        [StringLength(500)]
        public string? Field12 { get; set; }

        [StringLength(500)]
        public string? Field13 { get; set; }

        [StringLength(500)]
        public string? Field14 { get; set; }

        [StringLength(500)]
        public string? Field15 { get; set; }

        [StringLength(500)]
        public string? Field16 { get; set; }

        [StringLength(500)]
        public string? Field17 { get; set; }

        [StringLength(500)]
        public string? Field18 { get; set; }

        [StringLength(500)]
        public string? Field19 { get; set; }

        [StringLength(500)]
        public string? Field20 { get; set; }
    }
}
