using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_Balance
{
    public string? AccType { get; set; }

    public string? AccTypeName { get; set; }

    public string? AccCode { get; set; }

    public string? AccName { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }
}
