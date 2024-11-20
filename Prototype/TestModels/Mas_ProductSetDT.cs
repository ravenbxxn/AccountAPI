using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_ProductSetDT
{
    public int ProductSetDTID { get; set; }

    public string ProductSetCode { get; set; } = null!;

    public int ItemNo { get; set; }

    public string ProductCode { get; set; } = null!;

    public int Qty { get; set; }

    public string? UnitStock { get; set; }
}
