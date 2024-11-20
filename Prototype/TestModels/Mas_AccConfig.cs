using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_AccConfig
{
    public string ConfigCode { get; set; } = null!;

    public string ConfigKey { get; set; } = null!;

    public string? ConfigValue { get; set; }
}
