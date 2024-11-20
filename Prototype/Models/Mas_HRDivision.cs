using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HRDivision
    {
        [Key]
        public int DivisionId { get; set; }

        [StringLength(255)]
        public string? DivisionName { get; set; }

        [StringLength(255)]
        public string? DivisionNameEN { get; set; }

        public int? CompanyId { get; set; }
    }
}
