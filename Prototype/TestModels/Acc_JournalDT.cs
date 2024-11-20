using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_JournalDT
{
    public int EntryId { get; set; }

    public int Seq { get; set; }

    public string? AccCode { get; set; }

    public string? AccName { get; set; }

    public string? AccDesc { get; set; }

    public decimal? Debit { get; set; }

    public decimal? Credit { get; set; }
}
