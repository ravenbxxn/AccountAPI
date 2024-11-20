using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vPV_All
{
    public int EntryId { get; set; }

    public string? JournalNo { get; set; }

    public DateTime? EntryDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? EntryBy { get; set; }

    public string? Description { get; set; }

    public decimal? TotalDebit { get; set; }

    public decimal? TotalCredit { get; set; }

    public int Seq { get; set; }

    public string? AccCode { get; set; }

    public string? AccName { get; set; }

    public string? AccDesc { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }
}
