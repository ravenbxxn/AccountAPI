using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_DocConfig
{
    public int DocConfigID { get; set; }

    public string? Category { get; set; }

    public string TName { get; set; } = null!;

    public string? EName { get; set; }

    public string Prefix { get; set; } = null!;

    public string? Number { get; set; }
}
