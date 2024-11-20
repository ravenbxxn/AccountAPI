using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Department
{
    public int DPID { get; set; }

    public string DPCODE { get; set; } = null!;

    public string TShortName { get; set; } = null!;

    public string? EShortName { get; set; }

    public string TFullName { get; set; } = null!;

    public string? EFullName { get; set; }

    public string? Department { get; set; }
}
