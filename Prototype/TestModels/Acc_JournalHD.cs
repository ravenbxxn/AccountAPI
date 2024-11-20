using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_JournalHD
{
    public int EntryId { get; set; }

    public string? JournalNo { get; set; }

    public DateTime? EntryDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? EntryBy { get; set; }

    public string? Description { get; set; }

    public decimal? TotalDebit { get; set; }

    public decimal? TotalCredit { get; set; }
}
