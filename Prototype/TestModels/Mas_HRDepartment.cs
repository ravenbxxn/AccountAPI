using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_HRDepartment
{
    public int DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public string? DepartmentNameEN { get; set; }

    public int? DivisionId { get; set; }

    public int? HeadDepartmentId { get; set; }
}
