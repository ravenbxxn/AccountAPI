using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_HREmployment
    {
 
        public int CompanyId { get; set; }

        public int PositionId { get; set; }

        public int StaffId { get; set; }

        public DateTime? AssignmentDate { get; set; }

        public int? Probationdays { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? ContractType { get; set; }

        [StringLength(50)]
        public string? ContractId { get; set; }

        public int? ContractDays { get; set; }
    }
}
