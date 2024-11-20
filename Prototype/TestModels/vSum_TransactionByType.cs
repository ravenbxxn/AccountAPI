using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_TransactionByType
{
    public string? Header { get; set; }

    public int? CountDoc { get; set; }

    public double? TotalAmount { get; set; }

    public string? NewDocNo { get; set; }
}
