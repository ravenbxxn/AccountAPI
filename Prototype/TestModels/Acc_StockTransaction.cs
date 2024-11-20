using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Acc_StockTransaction
{
    public int TransID { get; set; }

    public string TransNum { get; set; } = null!;

    public string TransType { get; set; } = null!;

    public string StockProductCode { get; set; } = null!;

    public int TransQty { get; set; }

    public decimal TransPrice { get; set; }

    public string TransCurrency { get; set; } = null!;

    public decimal TransRate { get; set; }

    public string? AssetAccCode { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string? RefDocNo { get; set; }

    public virtual Mas_Warehouse WarehouseCodeNavigation { get; set; } = null!;
}
