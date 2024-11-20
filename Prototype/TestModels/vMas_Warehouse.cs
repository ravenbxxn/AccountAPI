using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vMas_Warehouse
{
    public int WarehouseID { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Address { get; set; }

    public string? AssetAccCode { get; set; }

    public string? AssetAccName { get; set; }

    public string? AssetAccNameEN { get; set; }

    public string? AssetAccType { get; set; }

    public string? AssetAccTypeName { get; set; }

    public string? AssetAccTypeNameEN { get; set; }

    public string? AssetAccSide { get; set; }

    public string? AssetAccMainCode { get; set; }

    public string? AssetAccMainName { get; set; }

    public string? AssetAccMainNameEN { get; set; }

    public string? IncomeAccCode { get; set; }

    public string? IncomeAccName { get; set; }

    public string? IncomeAccNameEN { get; set; }

    public string? IncomeAccType { get; set; }

    public string? IncomeAccTypeName { get; set; }

    public string? IncomeAccTypeNameEN { get; set; }

    public string? IncomeAccSide { get; set; }

    public string? IncomeAccMainCode { get; set; }

    public string? IncomeAccMainName { get; set; }

    public string? IncomeAccMainNameEN { get; set; }

    public string? ExpenseAccCode { get; set; }

    public string? ExpenseAccName { get; set; }

    public string? ExpenseAccNameEN { get; set; }

    public string? ExpenseAccType { get; set; }

    public string? ExpenseAccTypeName { get; set; }

    public string? ExpenseAccTypeNameEN { get; set; }

    public string? ExpenseAccSide { get; set; }

    public string? ExpenseAccMainCode { get; set; }

    public string? ExpenseAccMainName { get; set; }

    public string? ExpenseAccMainNameEN { get; set; }
}
