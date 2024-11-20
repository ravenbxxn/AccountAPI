using System;
using System.Collections.Generic;

namespace APIPrototype.TestModels;

public partial class vStock_Card
{
    public int TransID { get; set; }

    public string AccDocNo { get; set; } = null!;

    public DateTime AccBatchDate { get; set; }

    public DateTime AccEffectiveDate { get; set; }

    public string PartyCode { get; set; } = null!;

    public string? PartyTaxCode { get; set; }

    public string PartyName { get; set; } = null!;

    public string PartyAddress { get; set; } = null!;

    public string IssueBy { get; set; } = null!;

    public string AccDocType { get; set; } = null!;

    public DateTime AccPostDate { get; set; }

    public DateTime FiscalYear { get; set; }

    public int DocStatus { get; set; }

    public string WarehouseCode { get; set; } = null!;

    public string StockProductCode { get; set; } = null!;

    public string? UnitStock { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductColor { get; set; }

    public string ProductBrand { get; set; } = null!;

    public int TransQty { get; set; }

    public decimal TransPrice { get; set; }

    public string TransCurrency { get; set; } = null!;

    public decimal TransRate { get; set; }

    public decimal? TransAmount { get; set; }

    public int QtyIN { get; set; }

    public int? QtyOUT { get; set; }

    public string? AccSourceDocNo { get; set; }

    public int? AccSourceDocItem { get; set; }

    public string SaleProductCode { get; set; } = null!;

    public string SalesDescription { get; set; } = null!;

    public string? AssetAccCode { get; set; }

    public string? AssetAccName { get; set; }

    public string? AssetAccMainCode { get; set; }

    public string? AssetAccMainName { get; set; }
}
