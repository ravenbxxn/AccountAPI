using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_AllType
{
    public int AccTypeID { get; set; }

    public string? AccTypeName { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }
}
