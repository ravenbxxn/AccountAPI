using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vMas_Product
{
    public int ProductID { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductBrand { get; set; } = null!;

    public string? ProductColor { get; set; }

    public int? ProductSize { get; set; }

    public string? ProductSizeUnit { get; set; }

    public decimal? ProductVolume { get; set; }

    public string? ProductVolumeUnit { get; set; }

    public string? UnitStock { get; set; }

    public string ProductTypeCode { get; set; } = null!;

    public int ProductTypeID { get; set; }

    public string ProductTypeName { get; set; } = null!;

    public int WarehouseID { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string WarehouseName { get; set; } = null!;

    public string? WarehouseLocation { get; set; }

    public string? WarehouseAddress { get; set; }

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

    public bool IsMaterial { get; set; }

    public bool IsService { get; set; }

    public decimal RateVat { get; set; }

    public decimal RateWht { get; set; }

    public string VatType { get; set; } = null!;
}
