using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_HRPosition
{
    public int PositionId { get; set; }

    public string? PositionName { get; set; }

    public string? PositionNameEN { get; set; }

    public int? LevelId { get; set; }

    public int? DepartmentId { get; set; }
}
