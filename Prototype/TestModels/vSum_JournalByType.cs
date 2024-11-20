using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vSum_JournalByType
{
    public string? Header { get; set; }

    public int? CountDoc { get; set; }

    public decimal? TotalDebit { get; set; }

    public decimal? TotalCredit { get; set; }

    public string? NewDocNo { get; set; }
}
