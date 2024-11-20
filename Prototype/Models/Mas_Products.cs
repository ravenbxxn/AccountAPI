using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string ProductName { get; set;} = string.Empty;

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Brand { get; set; } = string.Empty;

        [StringLength(30)]
        public string? Color { get; set; } = string.Empty;

        [Range(0,int.MaxValue)]
        public int? Size { get; set; }

        [StringLength(30)]
        public string? SizeUnit { get; set; } = string.Empty;

        [Range(0.0, (double)decimal.MaxValue)]
        public decimal? Volume { get; set; }

        [StringLength(30)]
        public string? VolumeUnit { get; set; } = string.Empty;

        [StringLength(50)]
        public string? UnitStock { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ProductTypeCode { get; set; } = string.Empty;

    }
}
