using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_HREmployment
{
    public int CompanyId { get; set; }

    public int PositionId { get; set; }

    public int StaffId { get; set; }

    public DateTime? AssignmentDate { get; set; }

    public int? Probationdays { get; set; }

    public DateTime? BeginDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? ContractType { get; set; }

    public string? ContractId { get; set; }

    public int? ContractDays { get; set; }
}
