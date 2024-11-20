using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vTrial_Balance
{
    public int? Period { get; set; }

    public string? AccMainCode { get; set; }

    public string? AccMainName { get; set; }

    public string? AccCode { get; set; }

    public string? AccName { get; set; }

    public decimal? Dr { get; set; }

    public decimal? Cr { get; set; }
}
