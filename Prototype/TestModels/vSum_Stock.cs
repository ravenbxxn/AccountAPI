using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_Stock
{
    public string? AssetAccCode { get; set; }

    public string? AssetAccName { get; set; }

    public decimal? TotalAmount { get; set; }

    public int? TotalQty { get; set; }

    public decimal? AvgPrice { get; set; }
}
