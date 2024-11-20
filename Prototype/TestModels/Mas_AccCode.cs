using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_AccCode
{
    public string AccCode { get; set; } = null!;

    public string? AccName { get; set; }

    public string? AccNameEN { get; set; }

    public int? AccTypeID { get; set; }

    public string? AccMainCode { get; set; }
}
