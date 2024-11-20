using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vStock_Onhand
{
    public string WarehouseCode { get; set; } = null!;

    public string StockProductCode { get; set; } = null!;

    public string? UnitStock { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductColor { get; set; }

    public string ProductBrand { get; set; } = null!;

    public string? AssetAccCode { get; set; }

    public string? AssetAccName { get; set; }

    public string? AssetAccMainCode { get; set; }

    public string? AssetAccMainName { get; set; }

    public int? SumQty { get; set; }

    public decimal? SumAmount { get; set; }

    public decimal? AvgPrice { get; set; }

    public int? QtyIN { get; set; }

    public int? QtyOUT { get; set; }
}
