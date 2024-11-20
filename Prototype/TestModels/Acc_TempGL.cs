using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_TempGL
{
    public string? AccCode { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? JournalNo { get; set; }

    public string? AccDesc { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }
}
