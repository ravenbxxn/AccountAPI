using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_ProductSetHD
{
    public int ProductSetHDID { get; set; }

    public string ProductSetCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? PromoCode { get; set; }

    public string? UnitStock { get; set; }

    public decimal SalesPrice { get; set; }

    public string? SalesCurrency { get; set; }

    public decimal SalesRate { get; set; }

    public string? IncomeAccCode { get; set; }

    public string? ExpenseAccCode { get; set; }
}
