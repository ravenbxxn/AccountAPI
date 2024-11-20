using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class Mas_ProductType
{
    public int ProductTypeID { get; set; }

    public string ProductTypeCode { get; set; } = null!;

    public string ProductTypeName { get; set; } = null!;

    public string WarehouseCode { get; set; } = null!;

    public bool IsMaterial { get; set; }

    public bool IsService { get; set; }

    public decimal RateVat { get; set; }

    public decimal RateWht { get; set; }

    public string VatType { get; set; } = null!;

    public virtual Mas_Warehouse WarehouseCodeNavigation { get; set; } = null!;
}
