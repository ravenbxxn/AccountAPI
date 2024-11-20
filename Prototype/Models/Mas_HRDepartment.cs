using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HRDepartment
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(255)]
        public string? DepartmentName { get; set; }

        [StringLength(255)]
        public string? DepartmentNameEN { get; set; }

        public int? DivisionId { get; set; }

        public int? HeadDepartmentId { get; set; }
    }
}
