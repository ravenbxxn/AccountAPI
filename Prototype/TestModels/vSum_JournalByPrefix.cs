using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_JournalByPrefix
{
    public string? Header { get; set; }

    public string? AccCode { get; set; }

    public string? AccName { get; set; }

    public decimal? Dr { get; set; }

    public decimal? Cr { get; set; }
}
