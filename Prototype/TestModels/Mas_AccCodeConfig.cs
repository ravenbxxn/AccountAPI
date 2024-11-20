using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_AccCodeConfig
{
    public string AccCode { get; set; } = null!;

    public string? DebitAccCode { get; set; }

    public string? CreditAccCode { get; set; }
}
