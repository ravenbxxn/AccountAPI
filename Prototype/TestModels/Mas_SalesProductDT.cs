using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_SalesProductDT
{
    public int SalesProductIDDT { get; set; }

    public string SalesProductCode { get; set; } = null!;

    public int SalesItemNo { get; set; }

    public string ProductSetCode { get; set; } = null!;

    public int TargetQty { get; set; }
}
