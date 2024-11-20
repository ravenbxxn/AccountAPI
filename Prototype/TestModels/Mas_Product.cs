using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Product
{
    public int ProductID { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string? Color { get; set; }

    public int? Size { get; set; }

    public string? SizeUnit { get; set; }

    public decimal? Volume { get; set; }

    public string? VolumeUnit { get; set; }

    public string? UnitStock { get; set; }

    public string ProductTypeCode { get; set; } = null!;
}
