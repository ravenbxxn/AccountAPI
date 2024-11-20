using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_Warehouse
{
    public int WarehouseID { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Address { get; set; }

    public string? AssetAccCode { get; set; }

    public string? IncomeAccCode { get; set; }

    public string? ExpenseAccCode { get; set; }

    public virtual ICollection<Acc_StockTransaction> Acc_StockTransactions { get; set; } = new List<Acc_StockTransaction>();

    public virtual ICollection<Mas_ProductType> Mas_ProductTypes { get; set; } = new List<Mas_ProductType>();
}
