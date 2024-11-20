using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrototype.Models
{
    public class Mas_Warehouse
    {
        [Key]
        public int WarehouseID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string WarehouseCode { get; set; } = null!;

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string? Location { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(10)]
        public string? AssetAccCode { get; set; }

        [StringLength(10)]
        public string? IncomeAccCode { get; set; }

        [StringLength(10)]
        public string? ExpenseAccCode { get; set; }
    }
}
